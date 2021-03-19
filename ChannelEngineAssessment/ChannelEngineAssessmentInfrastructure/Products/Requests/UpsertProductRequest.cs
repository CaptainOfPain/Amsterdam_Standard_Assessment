using System;
using System.Collections.Generic;
using System.Text;
using ChannelEngineAssessmentInfrastructure.Products.DTOs;

namespace ChannelEngineAssessmentInfrastructure.Products.Requests
{
    public class UpsertProductRequest
    {
        public string MerchantProductNo { get; }
        public List<ProductExtraDataDto> ExtraData { get; }
        public string Name { get; }
        public string Description { get; }
        public string Brand { get; }
        public string Size { get; }
        public string Color { get; }
        public string Ean { get; }
        public string ManufacturerProductNumber { get; }
        public int Stock { get; }
        public decimal Price { get; }
        public decimal MSRP { get; }
        public decimal PurchasePrice { get; }
        public string VatRateType { get; }
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

        public UpsertProductRequest(string merchantProductNo, 
            string name, string description, string brand, string size, string color, string ean, string manufacturerProductNumber,
            int stock, decimal price, decimal msrp, decimal purchasePrice, string vatRateType, decimal shippingCost, string shippingTime,
            string url, string imageUrl, string extraImageUrl1, string extraImageUrl2, string extraImageUrl3, string extraImageUrl4, string extraImageUrl5,
            string extraImageUrl6, string extraImageUrl7, string extraImageUrl8, string extraImageUrl9, string categoryTrail, List<ProductExtraDataDto> extraData)
        {
            MerchantProductNo = merchantProductNo;
            ExtraData = extraData;
            Name = name;
            Description = description;
            Brand = brand;
            Size = size;
            Color = color;
            Ean = ean;
            ManufacturerProductNumber = manufacturerProductNumber;
            Stock = stock;
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
