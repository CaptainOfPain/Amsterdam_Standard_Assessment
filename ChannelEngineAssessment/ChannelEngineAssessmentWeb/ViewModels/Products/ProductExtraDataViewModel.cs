using ChannelEngineAssessmentDomain.Products;

namespace ChannelEngineAssessmentWeb.ViewModels.Products
{
    public class ProductExtraDataViewModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public ProductExtraDataType Type { get; set; }
        public bool IsPublic { get; set; }
    }
}