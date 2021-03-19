using ChannelEngineAssessmentDomain.Products.DataStructures;
using ChannelEngineAssessmentShared.Domain;

namespace ChannelEngineAssessmentDomain.Products.Factories
{
    public interface IProductDomainFactory : IDomainFactory
    {
        Product Create(ProductDataStructure dataStructure);
    }
}