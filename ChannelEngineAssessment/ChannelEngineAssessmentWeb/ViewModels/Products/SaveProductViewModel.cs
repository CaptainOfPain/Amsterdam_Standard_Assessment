using System.Collections.Generic;
using ChannelEngineAssessmentDomain.Products;

namespace ChannelEngineAssessmentWeb.ViewModels.Products
{
    public class SaveProductViewModel
    {
        public string MerchantProductNo { get; set; }
        public bool IsActive { get; set; }
        public List<ProductExtraDataViewModel> ExtraData { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Ean { get; set; }
        public string ManufacturerProductNumber { get; set; }
        public decimal Price { get; set; }
        public decimal MSRP { get; set; }
        public decimal PurchasePrice { get; set; }
        public VatRateType VatRateType { get; set; }
        public decimal ShippingCost { get; set; }
        public string ShippingTime { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<string> ExtraImageUrls { get; set; }
        public string CategoryTrail { get; set; }
    }
}