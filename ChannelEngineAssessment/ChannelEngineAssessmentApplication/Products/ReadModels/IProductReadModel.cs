using System.Collections.Generic;
using System.Threading.Tasks;
using ChannelEngineAssessmentInfrastructure;
using ChannelEngineAssessmentInfrastructure.Products.DTOs;
using ChannelEngineAssessmentInfrastructure.Products.Queries;
using ChannelEngineAssessmentShared.Infrastructure.Abstractions;

namespace ChannelEngineAssessmentApplication.Products.ReadModels
{
    public interface IProductReadModel : IReadModel
    {
        Task<ProductDto> GetProductAsync(GetProductQuery query);
        Task<ListResultDto<TopSoldProductDto>> GetTopSoldProducts(GetTopSoldProductsQuery query);
    }
}
