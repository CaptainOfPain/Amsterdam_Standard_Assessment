using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChannelEngineAssessmentDomain.MerchantOrders;
using ChannelEngineAssessmentInfrastructure.MerchantOrders.DTOs;
using ChannelEngineAssessmentShared.Configurations;
using ChannelEngineAssessmentShared.Domain;
using ChannelEngineAssessmentShared.Extensions;
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

        public async Task<IEnumerable<MerchantOrder>> BrowseAsync(IEnumerable<OrderStatus> statuses = null, IEnumerable<string> emailAddresses = null, DateTime? fromDate = null, DateTime? toDate = null,
            DateTime? fromCreatedAtDate = null)
        {
            var restRequest = new RestRequest(_applicationConfiguration.Endpoints.GetOrdersEndpoint);
            ApplyWhereStatement(restRequest, statuses, emailAddresses, fromDate, toDate, fromCreatedAtDate);

            var orders = await _genericRestRepository.GetAsync<MerchantOrderResponseListDto>(restRequest);
            return _mapper.Map<IEnumerable<MerchantOrder>>(orders.Content);
        }

        private void ApplyWhereStatement(RestRequest restRequest, IEnumerable<OrderStatus> statuses, IEnumerable<string> emailAddresses, DateTime? fromDate, DateTime? toDate, DateTime? fromCreatedAtDate)
        {
            if (statuses != null && statuses.Any())
            {
                foreach (var orderStatus in statuses)
                {
                    restRequest.AddParameter(nameof(statuses), orderStatus.GetEnumMemberValue(), ParameterType.QueryString);
                }
            }

            if (emailAddresses != null && emailAddresses.Any())
            {
                foreach (var emailAddress in emailAddresses)
                {
                    restRequest.AddParameter(nameof(emailAddresses), emailAddress, ParameterType.QueryString);
                }
            }

            if (fromDate.HasValue)
            {
                restRequest.AddParameter(nameof(fromDate), fromDate, ParameterType.QueryString);
            }

            if (toDate.HasValue)
            {
                restRequest.AddParameter(nameof(toDate), toDate, ParameterType.QueryString);
            }

            if (fromCreatedAtDate.HasValue)
            {
                restRequest.AddParameter(nameof(fromCreatedAtDate), fromCreatedAtDate, ParameterType.QueryString);
            }
        }
    }
}