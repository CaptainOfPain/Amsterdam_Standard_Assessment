using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using ChannelEngineAssessmentDomain.MerchantOrders;
using ChannelEngineAssessmentInfrastructure;
using ChannelEngineAssessmentInfrastructure.MerchantOrders.Repositories;
using ChannelEngineAssessmentInfrastructure.Products.DTOs;
using ChannelEngineAssessmentInfrastructure.Products.Queries;
using ChannelEngineAssessmentShared.Application.Handlers.Abstraction;
using ChannelEngineAssessmentWeb;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace ChannelEngineAssessmentTests
{
    public class ProductIntegrationTests
    {
        private readonly TestServer _server;
        private readonly ILifetimeScope _scope;
        private readonly ICommandQueryDispatcherDecorator _commandQueryDispatcher;

        public ProductIntegrationTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseConfiguration(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build())
                .ConfigureServices((services => ServiceCollectionExtensions.AddAutofac(services, null)))
                .UseStartup<Startup>());
            _scope  = _server.Host.Services.GetService<ILifetimeScope>() ?? throw new ArgumentNullException(nameof(_scope));
            _commandQueryDispatcher = _scope.Resolve<ICommandQueryDispatcherDecorator>();
        }

        [Fact]
        public void ShouldGetMaximumFiveProductsFromRepository()
        {
            var query = new GetTopSoldProductsQuery(5);
            var dto = _commandQueryDispatcher.DispatchAsync<GetTopSoldProductsQuery, ListResultDto<TopSoldProductDto>>(query).GetAwaiter().GetResult();

            Assert.NotNull(dto);
            Assert.True(dto.Items.Count() <= 5);
        }

        [Fact]
        public void ShouldGetOnlyOrdersInProgressStatus()
        {
            var repository = _scope.Resolve<IMerchantOrderRepository>();
            var result = repository.BrowseAsync(new List<OrderStatus>() {OrderStatus.InProgress}).GetAwaiter().GetResult();

            Assert.NotNull(result);
            Assert.All(result, o => o.Status.Equals(OrderStatus.InProgress));
        }
    }
}
