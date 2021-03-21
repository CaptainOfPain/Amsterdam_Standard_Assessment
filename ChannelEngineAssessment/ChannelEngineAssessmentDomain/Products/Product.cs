using System;
using System.Collections.Generic;
using System.Linq;
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


        private  List<ExtraImageUrl> _extraImageUrls = new List<ExtraImageUrl>();
        public IEnumerable<ExtraImageUrl> ExtraImageUrls
        {
            get => _extraImageUrls;
            private set => _extraImageUrls = value.ToList();
        }

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
            UpdateUpdatedAt();
        }

        public void SetStock(int stock)
        {
            if (stock < 0)
            {
                throw new BusinessLogicException(ProductResources.StockHasToBeZeroOrPositiveMessage);
            }

            Stock = stock;
            UpdateUpdatedAt();
        }

        public int AddExtraImageUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new BusinessLogicException(ProductResources.WrongImageUrlMessage);
            }

            var extraImageUrl = new ExtraImageUrl(GetNextExtraImageUrlNo, url);
            _extraImageUrls.Add(new ExtraImageUrl(GetNextExtraImageUrlNo, url));

            return extraImageUrl.No;
        }

        public void AddExtraImageUrls(IEnumerable<string> urls)
        {
            foreach (var url in urls)
            {
                AddExtraImageUrl(url);
            }
        }

        public void RemoveExtraImageUrl(int no)
        {
            var extraImageUrl = GetExtraImageUrlOrThrow(no);
            _extraImageUrls.Remove(extraImageUrl);
        }

        public void UpdateExternalImageUrl(int no, string url)
        {
            var extraImageUrl = GetExtraImageUrlOrThrow(no);
            extraImageUrl.Update(url);
        }

        private void AssignFromDataStructure(ProductDataStructure dataStructure)
        {
            IsActive = dataStructure.IsActive;
            ExtraData = dataStructure.ExtraData;
            SetName(dataStructure.Name);
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
            CategoryTrail = dataStructure.CategoryTrail;
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessLogicException(ProductResources.NameCannotBeEmptyMessage);
            }

            Name = name;
        }

        private int GetNextExtraImageUrlNo
            => _extraImageUrls.Any() ? _extraImageUrls.Max(x => x.No) + 1 : 1;

        private ExtraImageUrl GetExtraImageUrlOrThrow(int no)
        {
            var extraImageUrl = _extraImageUrls.SingleOrDefault(x => x.No == no);
            if (extraImageUrl == null)
            {
                throw new BusinessLogicException(ProductResources.ExternalImageUrlNotFoundMessage);
            }

            return extraImageUrl;
        }
    }
}
