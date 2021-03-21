using System;
using Autofac;
using ChannelEngineAssessmentApplication.Products;
using ChannelEngineAssessmentDomain.MerchantOrders;
using ChannelEngineAssessmentDomain.MerchantOrders.Factories;
using ChannelEngineAssessmentInfrastructure.MerchantOrders.Repositories;
using ChannelEngineAssessmentShared.Configurations;
using ChannelEngineAssessmentShared.IoC;
using ChannelEngineAssessmentWeb.MappingProfiles.Products;
using ChannelEngineAssessmentWeb.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ChannelEngineAssessmentWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var endpointsConfiguration = new ApiEndpointsConfiguration();
            Configuration.GetSection("AppConfiguration:Endpoints").Bind(endpointsConfiguration);
            builder.RegisterModule(new ApplicationConfigurationModule(
                new ApplicationConfiguration(
                    Configuration["AppConfiguration:BaseApiUrl"],
                    Convert.ToBoolean(Configuration["AppConfiguration:ThrowOnApiError"]),
                    Convert.ToBoolean(Configuration["AppConfiguration:FailOnApiDeserializationError"]),
                    Configuration["AppConfiguration:ApiKeyNameUrlParameter"],
                    Configuration["AppConfiguration:ApiKey"],
                    endpoints: endpointsConfiguration)));
            builder.RegisterModule(new ApplicationMappingsModule(typeof(ProductsService).Assembly, typeof(MerchantOrderRepository).Assembly, typeof(ProductsControllerMappingProfile).Assembly));
            builder.RegisterModule(new ApplicationHandlersModule<ProductsService>());
            builder.RegisterModule(new ApplicationRepositoriesModule<MerchantOrderRepository>());
            builder.RegisterModule(new ApplicationFactoriesModule<MerchantOrderDomainFactory>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseApplicationExceptionMiddleware();
            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
