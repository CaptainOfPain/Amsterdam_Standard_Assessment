using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChannelEngineAssessmentShared.Domain;

namespace ChannelEngineAssessmentDomain.Products.DataStructures
{
    public class ProductDataStructure
    {
        public AggregateId MerchantProductNo { get; }
        public bool IsActive { get; }
        public List<ProductExtraData> ExtraData { get; }
        public string Name { get; }
        public string Description { get; }
        public string Brand { get; }
        public string Size { get; }
        public string Color { get; }
        public string Ean { get; }
        public string ManufacturerProductNumber { get; }
        public decimal Price { get; }
        public decimal MSRP { get; }
        public decimal PurchasePrice { get; }
        public VatRateType VatRateType { get; }
        public decimal ShippingCost { get; }
        public string ShippingTime { get; }
        public string Url { get; }
        public string ImageUrl { get; }
        public IEnumerable<string> ExtraImageUrls { get; }
        public string CategoryTrail { get; }

        public ProductDataStructure(AggregateId merchantProductNo, bool isActive, List<ProductExtraData> extraData, 
            string name, string description, string brand, string size, string color, string ean, 
            string manufacturerProductNumber, decimal price, decimal msrp, decimal purchasePrice, 
            VatRateType vatRateType, decimal shippingCost, string shippingTime, string url, string imageUrl, 
            string categoryTrail, IEnumerable<string> extraImageUrls)
        {
            MerchantProductNo = merchantProductNo;
            IsActive = isActive;
            ExtraData = extraData;
            Name = name;
            Description = description;
            Brand = brand;
            Size = size;
            Color = color;
            Ean = ean;
            ManufacturerProductNumber = manufacturerProductNumber;
            Price = price;
            MSRP = msrp;
            PurchasePrice = purchasePrice;
            VatRateType = vatRateType;
            ShippingCost = shippingCost;
            ShippingTime = shippingTime;
            Url = url;
            ImageUrl = imageUrl;
            CategoryTrail = categoryTrail;
            ExtraImageUrls = extraImageUrls?.ToList() ?? new List<string>();
        }
    }
}
