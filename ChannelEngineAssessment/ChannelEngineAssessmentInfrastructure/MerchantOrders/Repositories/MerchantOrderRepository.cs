using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChannelEngineAssessmentDomain.MerchantOrders;
using ChannelEngineAssessmentInfrastructure.MerchantOrders.DTOs;
using ChannelEngineAssessmentShared.Configurations;
using ChannelEngineAssessmentShared.Domain;
using ChannelEngineAssessmentShared.Infrastructure.Repositories.Abstractions;
using RestSharp;

namespace ChannelEngineAssessmentInfrastructure.MerchantOrders.Repositories
{
    public class MerchantOrderRepository : IMerchantOrderRepository
    {
        private readonly IGenericRestRepository _genericRestRepository;
        private readonly IApplicationConfiguration _applicationConfiguration;
        private readonly IMapper _mapper;

        public MerchantOrderRepository(IGenericRestRepository genericRestRepository, IApplicationConfiguration applicationConfiguration, IMapper mapper)
        {
            _genericRestRepository = genericRestRepository ?? throw new ArgumentNullException(nameof(genericRestRepository));
            _applicationConfiguration = applicationConfiguration ?? throw new ArgumentNullException(nameof(applicationConfiguration));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task CreateAsync(MerchantOrder aggregate)
        {
            //TODO not implemented in REST API
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(MerchantOrder aggregate)
        {
            //TODO not implemented in REST API
            throw new System.NotImplementedException();
        }

        public async Task<MerchantOrder> GetAsync(AggregateId id)
        {
            var restRequest = new RestRequest(_applicationConfiguration.Endpoints.GetOrdersEndpoint);
            restRequest.AddParameter("channelOrderNos", id.Id, ParameterType.QueryString);

            var orders = await _genericRestRepository.GetAsync<MerchantOrderResponseListDto>(restRequest);
            return _mapper.Map<MerchantOrder>(orders.Content.FirstOrDefault());
        }

        public async Task<IEnumerable<MerchantOrder>> GetAllAsync()
        {
            var restRequest = new RestRequest(_applicationConfiguration.Endpoints.GetOrdersEndpoint);

            var orders = await _genericRestRepository.GetAsync<MerchantOrderResponseListDto>(restRequest);
            return _mapper.Map<IEnumerable<MerchantOrder>>(orders.Content);
        }

        public Task DeleteAsync(AggregateId id)
        {
            //TODO not implemented in REST API
            throw new System.NotImplementedException();
        }
    }
}