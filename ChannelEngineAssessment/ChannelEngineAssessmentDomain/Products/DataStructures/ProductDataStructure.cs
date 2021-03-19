using System;
using System.Collections.Generic;
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
        public string ExtraImageUrl1 { get; }
        public string ExtraImageUrl2 { get; }
        public string ExtraImageUrl3 { get; }
        public string ExtraImageUrl4 { get; }
        public string ExtraImageUrl5 { get; }
        public string ExtraImageUrl6 { get; }
        public string ExtraImageUrl7 { get; }
        public string ExtraImageUrl8 { get; }
        public string ExtraImageUrl9 { get; }
        public string CategoryTrail { get; }

        public ProductDataStructure(AggregateId merchantProductNo, bool isActive, List<ProductExtraData> extraData, string name, string description, string brand, string size, string color, string ean, string manufacturerProductNumber, decimal price, decimal msrp, decimal purchasePrice, VatRateType vatRateType, decimal shippingCost, string shippingTime, string url, string imageUrl, string extraImageUrl1, string extraImageUrl2, string extraImageUrl3, string extraImageUrl4, string extraImageUrl5, string extraImageUrl6, string extraImageUrl7, string extraImageUrl8, string extraImageUrl9, string categoryTrail)
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
            ExtraImageUrl1 = extraImageUrl1;
            ExtraImageUrl2 = extraImageUrl2;
            ExtraImageUrl3 = extraImageUrl3;
            ExtraImageUrl4 = extraImageUrl4;
            ExtraImageUrl5 = extraImageUrl5;
            ExtraImageUrl6 = extraImageUrl6;
            ExtraImageUrl7 = extraImageUrl7;
            ExtraImageUrl8 = extraImageUrl8;
            ExtraImageUrl9 = extraImageUrl9;
            CategoryTrail = categoryTrail;
        }
    }
}
