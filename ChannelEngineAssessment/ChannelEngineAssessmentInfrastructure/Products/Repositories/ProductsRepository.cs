using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ChannelEngineAssessmentDomain.Products;
using ChannelEngineAssessmentInfrastructure.Products.DTOs;
using ChannelEngineAssessmentInfrastructure.Products.Requests;
using ChannelEngineAssessmentShared.Configurations;
using ChannelEngineAssessmentShared.Domain;
using ChannelEngineAssessmentShared.Infrastructure.Repositories.Abstractions;
using RestSharp;

namespace ChannelEngineAssessmentInfrastructure.Products.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly IGenericRestRepository _genericRestRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationConfiguration _applicationConfiguration;

        public ProductsRepository(IGenericRestRepository genericRestRepository, IMapper mapper, IApplicationConfiguration applicationConfiguration)
        {
            _genericRestRepository = genericRestRepository ?? throw new ArgumentNullException(nameof(genericRestRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _applicationConfiguration = applicationConfiguration ?? throw new ArgumentNullException(nameof(applicationConfiguration));
        }

        public async Task CreateAsync(Product aggregate)
        {
            var restRequest = new RestRequest(_applicationConfiguration.Endpoints.SetProductEndpoint);
            restRequest.AddJsonBody(_mapper.Map<UpsertProductRequest>(aggregate));

            await _genericRestRepository.PostAsync<object>(restRequest);
        }

        public async Task UpdateAsync(Product aggregate)
        {
            await CreateAsync(aggregate);
        }

        public async Task<Product> GetAsync(AggregateId id)
        {
            var restRequest = new RestRequest(_applicationConfiguration.Endpoints.GetProductEndpoint);
            restRequest.AddParameter(nameof(id), id, ParameterType.UrlSegment);

            var result = await _genericRestRepository.GetAsync<SingleResponseDto<ProductDto>>(restRequest);
            return _mapper.Map<Product>(result.Content);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var restRequest = new RestRequest(_applicationConfiguration.Endpoints.GetProductsEndpoint);

            var result = await _genericRestRepository.GetAsync<ListResponseDto<ProductDto>>(restRequest);
            return _mapper.Map<IEnumerable<Product>>(result.Content);
        }

        public async Task DeleteAsync(AggregateId id)
        {
            var restRequest = new RestRequest(_applicationConfiguration.Endpoints.DeleteProductEndpoint);
            restRequest.AddParameter(nameof(id), id, ParameterType.UrlSegment);

            await _genericRestRepository.DeleteAsync<object>(restRequest);
        }
    }
}