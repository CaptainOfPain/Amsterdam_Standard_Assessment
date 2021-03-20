using System.Collections.Generic;
using System.Threading.Tasks;
using ChannelEngineAssessmentDomain.Products;
using ChannelEngineAssessmentShared.Infrastructure.Repositories.Abstractions;

namespace ChannelEngineAssessmentInfrastructure.Products.Repositories
{
    public interface IProductsRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> BrowseAsync(IEnumerable<string> merchantProductNoList = null);
    }
}
