using ChannelEngineAssessmentDomain.MerchantOrders.DataStructures;
using ChannelEngineAssessmentShared.Domain;

namespace ChannelEngineAssessmentDomain.MerchantOrders.Factories
{
    public interface IMerchantOrderDomainFactory : IDomainFactory
    {
        MerchantOrder Create(MerchantOrderDataStructure dataStructure);
    }
}
