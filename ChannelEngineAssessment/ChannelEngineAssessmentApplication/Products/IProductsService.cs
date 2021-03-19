using System.Threading.Tasks;
using ChannelEngineAssessmentDomain.Products.DataStructures;
using ChannelEngineAssessmentShared.Application.Services;
using ChannelEngineAssessmentShared.Domain;

namespace ChannelEngineAssessmentApplication.Products
{
    public interface IProductsService : IService
    {
        Task CreateAsync(ProductDataStructure productDataStructure);
        Task UpdateAsync(ProductDataStructure productDataStructure);
        Task SetStockAsync(AggregateId id, int newStock);
        Task DeleteAsync(AggregateId id);
    }
}