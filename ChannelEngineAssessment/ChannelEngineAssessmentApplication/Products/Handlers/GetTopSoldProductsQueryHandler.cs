using System;
using System.Threading.Tasks;
using ChannelEngineAssessmentApplication.Products.ReadModels;
using ChannelEngineAssessmentInfrastructure;
using ChannelEngineAssessmentInfrastructure.Products.DTOs;
using ChannelEngineAssessmentInfrastructure.Products.Queries;
using ChannelEngineAssessmentShared.Application.Handlers.Abstraction;

namespace ChannelEngineAssessmentApplication.Products.Handlers
{
    public class GetTopSoldProductsQueryHandler : IQueryHandler<GetTopSoldProductsQuery, ListResultDto<TopSoldProductDto>>
    {
        private readonly IProductReadModel _productReadModel;

        public GetTopSoldProductsQueryHandler(IProductReadModel productReadModel)
        {
            _productReadModel = productReadModel ?? throw new ArgumentNullException(nameof(_productReadModel));
        }

        public async Task<ListResultDto<TopSoldProductDto>> HandleAsync(GetTopSoldProductsQuery query)
            => await _productReadModel.GetTopSoldProducts(query);
    }
}