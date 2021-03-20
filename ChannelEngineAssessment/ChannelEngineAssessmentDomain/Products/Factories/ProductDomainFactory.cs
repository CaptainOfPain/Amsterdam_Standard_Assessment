using ChannelEngineAssessmentDomain.Products.DataStructures;

namespace ChannelEngineAssessmentDomain.Products.Factories
{
    public class ProductDomainFactory : IProductDomainFactory
    {
        public Product Create(ProductDataStructure dataStructure)
        { 
            var product = new Product(dataStructure.MerchantProductNo, dataStructure);
            product.AddExtraImageUrls(dataStructure.ExtraImageUrls);

            return product;
        } 
    }
}
