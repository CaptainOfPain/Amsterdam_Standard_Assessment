using ChannelEngineAssessmentDomain.MerchantOrders;
using ChannelEngineAssessmentShared.Infrastructure.Factories;
using ChannelEngineAssessmentShared.Infrastructure.Repositories.Abstractions;

namespace ChannelEngineAssessmentInfrastructure.MerchantOrders.Repositories
{
    public interface IMerchantOrderRepository : IGenericRepository<MerchantOrder>
    {
    }
}
