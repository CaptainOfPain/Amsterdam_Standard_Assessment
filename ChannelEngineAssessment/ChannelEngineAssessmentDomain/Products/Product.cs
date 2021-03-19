using System;
using System.Collections.Generic;
using ChannelEngineAssessmentDomain.Products.DataStructures;
using ChannelEngineAssessmentDomain.Products.Resources;
using ChannelEngineAssessmentShared.Domain;
using ChannelEngineAssessmentShared.Exceptions;

namespace ChannelEngineAssessmentDomain.Products
{
    public class Product : AggregateRoot
    {
        public bool IsActive { get; private set; }
        public List<ProductExtraData> ExtraData { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Brand { get; private set; }
        public string Size { get; private set; }
        public string Color { get; private set; }
        public string Ean { get; private set; }
        public string ManufacturerProductNumber { get; private set; }
        public int Stock { get; private set; }
        public decimal Price { get; private set; }
        public decimal MSRP { get; private set; }
        public decimal PurchasePrice { get; private set; }
        public VatRateType VatRateType { get; private set; }
        public decimal ShippingCost { get; private set; }
        public string ShippingTime { get; private set; }
        public string Url { get; private set; }
        public string ImageUrl { get; private set; }
        public string ExtraImageUrl1 { get; private set; }
        public string ExtraImageUrl2 { get; private set; }
        public string ExtraImageUrl3 { get; private set; }
        public string ExtraImageUrl4 { get; private set; }
        public string ExtraImageUrl5 { get; private set; }
        public string ExtraImageUrl6 { get; private set; }
        public string ExtraImageUrl7 { get; private set; }
        public string ExtraImageUrl8 { get; private set; }
        public string ExtraImageUrl9 { get; private set; }
        public string CategoryTrail { get; private set; }

        internal Product(AggregateId id, ProductDataStructure dataStructure) : base(id)
        {
            AssignFromDataStructure(dataStructure);
        }

        private Product()
        {
            
        }

        public void Update(ProductDataStructure dataStructure)
        {
            AssignFromDataStructure(dataStructure);
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetStock(int stock)
        {
            if (stock < 0)
            {
                throw new BusinessLogicException(ProductResources.StockHasToBeZeroOrPositiveMessage);
            }

            Stock = stock;
        }

        private void AssignFromDataStructure(ProductDataStructure dataStructure)
        {
            IsActive = dataStructure.IsActive;
            ExtraData = dataStructure.ExtraData;
            Name = dataStructure.Name;
            Description = dataStructure.Description;
            Brand = dataStructure.Brand;
            Size = dataStructure.Size;
            Color = dataStructure.Color;
            Ean = dataStructure.Ean;
            ManufacturerProductNumber = dataStructure.ManufacturerProductNumber;
            Price = dataStructure.Price;
            MSRP = dataStructure.MSRP;
            PurchasePrice = dataStructure.PurchasePrice;
            VatRateType = dataStructure.VatRateType;
            ShippingCost = dataStructure.ShippingCost;
            ShippingTime = dataStructure.ShippingTime;
            Url = dataStructure.Url;
            ImageUrl = dataStructure.ImageUrl;
            ExtraImageUrl1 = dataStructure.ExtraImageUrl1;
            ExtraImageUrl2 = dataStructure.ExtraImageUrl2;
            ExtraImageUrl3 = dataStructure.ExtraImageUrl3;
            ExtraImageUrl4 = dataStructure.ExtraImageUrl4;
            ExtraImageUrl5 = dataStructure.ExtraImageUrl5;
            ExtraImageUrl6 = dataStructure.ExtraImageUrl6;
            ExtraImageUrl7 = dataStructure.ExtraImageUrl7;
            ExtraImageUrl8 = dataStructure.ExtraImageUrl8;
            ExtraImageUrl9 = dataStructure.ExtraImageUrl9;
            CategoryTrail = dataStructure.CategoryTrail;
        }
    }
}
