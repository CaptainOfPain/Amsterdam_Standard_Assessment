using ChannelEngineAssessmentDomain.Products;

namespace ChannelEngineAssessmentInfrastructure.Products.DTOs
{
    public class ProductExtraDataDto
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public ProductExtraDataType Type { get; set; }
        public bool IsPublic { get; set; }
    }
}