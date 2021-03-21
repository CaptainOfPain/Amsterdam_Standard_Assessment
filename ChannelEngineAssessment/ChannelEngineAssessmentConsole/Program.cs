using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Extras.DynamicProxy;
using ChannelEngineAssessmentApplication.Products;
using ChannelEngineAssessmentConsole.Models;
using ChannelEngineAssessmentConsole.Windows;
using ChannelEngineAssessmentDomain.MerchantOrders.Factories;
using ChannelEngineAssessmentInfrastructure.MerchantOrders.Repositories;
using ChannelEngineAssessmentShared.Application.Handlers.Abstraction;
using ChannelEngineAssessmentShared.Application.Handlers.Implementations;
using ChannelEngineAssessmentShared.Configurations;
using ChannelEngineAssessmentShared.Exceptions;
using ChannelEngineAssessmentShared.IoC;
using ChannelEngineAssessmentWeb.MappingProfiles.Products;
using Microsoft.Extensions.Configuration;
using NStack;
using Terminal.Gui;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace ChannelEngineAssessmentConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = ConfigureContainer();

            Application.Init();
            var top = Application.Top;
            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.X = 0;
            mainWindow.Y = 0;
            mainWindow.Width = Dim.Fill();
            mainWindow.Height = Dim.Fill();

            top.Add(mainWindow);
            try
            {
                Application.Run();
            }
            catch (Exception ex)
            {
                if (ex is HttpClientUnhandledException ce)
                {
                    MessageBox.ErrorQuery("Error", $"Api error, HTTP Code: {ce.StatusCode}", "Ok");
                    Main(args);
                }

                else if (ex is BusinessLogicException be)
                {
                    MessageBox.ErrorQuery("Error", be.Message, "Ok");
                    Main(args);
                }
                else
                {
                    throw;
                }
            }
        }

        public static IContainer ConfigureContainer()
        {
            var containerBuilder = new ContainerBuilder();
            IConfiguration Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var endpointsConfiguration = new ApiEndpointsConfiguration();
            Configuration.GetSection("AppConfiguration:Endpoints").Bind(endpointsConfiguration);
            containerBuilder.RegisterModule(new ApplicationConfigurationModule(
                new ApplicationConfiguration(
                    Configuration["AppConfiguration:BaseApiUrl"],
                    Convert.ToBoolean(Configuration["AppConfiguration:ThrowOnApiError"]),
                    Convert.ToBoolean(Configuration["AppConfiguration:FailOnApiDeserializationError"]),
                    Configuration["AppConfiguration:ApiKeyNameUrlParameter"],
                    Configuration["AppConfiguration:ApiKey"],
                    endpoints: endpointsConfiguration)));
            containerBuilder.RegisterModule(new ApplicationMappingsModule(typeof(ProductsService).Assembly, typeof(MerchantOrderRepository).Assembly, typeof(TopSoldProductTerminalModel).Assembly));
            containerBuilder.RegisterModule(new ApplicationHandlersModule<ProductsService>());
            containerBuilder.RegisterModule(new ApplicationRepositoriesModule<MerchantOrderRepository>());
            containerBuilder.RegisterModule(new ApplicationFactoriesModule<MerchantOrderDomainFactory>());
            containerBuilder.RegisterType<MainWindow>().AsSelf().InstancePerLifetimeScope();

            return containerBuilder.Build();
        }
    }
}
