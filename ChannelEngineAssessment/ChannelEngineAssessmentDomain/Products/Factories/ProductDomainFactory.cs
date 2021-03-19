using ChannelEngineAssessmentDomain.Products.DataStructures;

namespace ChannelEngineAssessmentDomain.Products.Factories
{
    public class ProductDomainFactory : IProductDomainFactory
    {
        public Product Create(ProductDataStructure dataStructure)
            => new Product(dataStructure.MerchantProductNo, dataStructure);
    }
}
