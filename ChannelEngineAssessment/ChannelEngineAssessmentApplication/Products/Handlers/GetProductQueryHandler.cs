using System;
using System.Threading.Tasks;
using ChannelEngineAssessmentApplication.Products.ReadModels;
using ChannelEngineAssessmentInfrastructure.Products.DTOs;
using ChannelEngineAssessmentInfrastructure.Products.Queries;
using ChannelEngineAssessmentShared.Application.Handlers.Abstraction;

namespace ChannelEngineAssessmentApplication.Products.Handlers
{
    public class GetProductQueryHandler : IQueryHandler<GetProductQuery, ProductDto>
    {
        private readonly IProductReadModel _productReadModel;

        public GetProductQueryHandler(IProductReadModel productReadModel)
        {
            _productReadModel = productReadModel ?? throw new ArgumentNullException(nameof(productReadModel));
        }

        public async Task<ProductDto> HandleAsync(GetProductQuery query)
            => await _productReadModel.GetProductAsync(query);
    }
}
