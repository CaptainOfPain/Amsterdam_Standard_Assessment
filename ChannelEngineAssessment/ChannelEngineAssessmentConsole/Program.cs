using System;
using Autofac;
using AutoMapper.Configuration;
using ChannelEngineAssessmentApplication.Products;
using ChannelEngineAssessmentDomain.MerchantOrders.Factories;
using ChannelEngineAssessmentInfrastructure.MerchantOrders.Repositories;
using ChannelEngineAssessmentShared.Configurations;
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
            containerBuilder.RegisterModule(new ApplicationMappingsModule(typeof(ProductsService).Assembly, typeof(MerchantOrderRepository).Assembly, typeof(ProductsControllerMappingProfile).Assembly));
            containerBuilder.RegisterModule(new ApplicationHandlersModule<ProductsService>());
            containerBuilder.RegisterModule(new ApplicationRepositoriesModule<MerchantOrderRepository>());
            containerBuilder.RegisterModule(new ApplicationFactoriesModule<MerchantOrderDomainFactory>());

            Application.Init();
            var top = Application.Top;

            // Creates the top-level window to show
            var win = new Window("MyApp")
            {
                X = 0,
                Y = 1, // Leave one row for the toplevel menu

                // By using Dim.Fill(), it will automatically resize without manual intervention
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            top.Add(win);
            var login = new Label("Login: ") { X = 3, Y = 2 };
            var password = new Label("Password: ")
            {
                X = Pos.Left(login),
                Y = Pos.Top(login) + 1
            };
            var loginText = new TextField("")
            {
                X = Pos.Right(password),
                Y = Pos.Top(login),
                Width = 40
            };
            var passText = new TextField("")
            {
                Secret = true,
                X = Pos.Left(loginText),
                Y = Pos.Top(password),
                Width = Dim.Width(loginText)
            };

            // Add some controls, 
            win.Add(
                // The ones with my favorite layout system, Computed
                login, password, loginText, passText,

                // The ones laid out like an australopithecus, with Absolute positions:
                new CheckBox(3, 6, "Remember me"),
                new RadioGroup(3, 8, new ustring[] { "_Personal", "_Company" }),
                new Button(3, 14, "Ok"),
                new Button(10, 14, "Cancel"),
                new Label(3, 18, "Press F9 or ESC plus 9 to activate the menubar")
            );
			Application.Run();
		}
    }
}
