using System.Collections.Generic;
using ChannelEngineAssessmentDomain.Products;
using ChannelEngineAssessmentDomain.Products.DataStructures;
using ChannelEngineAssessmentDomain.Products.Factories;
using ChannelEngineAssessmentShared.Domain;
using ChannelEngineAssessmentShared.Exceptions;
using Xunit;

namespace ChannelEngineAssessmentTests
{
    public class ProductTests
    {
        public ProductTests()
        {
        }

        [Fact]
        public void ShouldCreateProduct()
        {
            var product = CreateProduct();
            Assert.NotNull(product);
        }

        [Fact]
        public void ShouldThrowBusinessLogicExceptionWhenNameIsEmptyOnUpdate()
        {
            var product = CreateProduct();
            
            Assert.Throws<BusinessLogicException>(() =>product.Update(new ProductDataStructure(
                AggregateId.Generate(),
                true,
                new List<ProductExtraData>(),
                "",
                "Test",
                "Test",
                "test",
                "color",
                "ean",
                "134",
                12,
                12,
                12,
                VatRateType.Standard,
                12,
                "shipping time",
                "url",
                "imageUrl",
                "categoryTrail",
                new List<string>())));
        }

        [Fact]
        public void ShouldChangeNameOfProduct()
        {
            var product = CreateProduct();
            var newName = "NOWY TEST";
            product.Update(new ProductDataStructure(
                AggregateId.Generate(),
                true,
                new List<ProductExtraData>(),
                newName,
                "Test",
                "Test",
                "test",
                "color",
                "ean",
                "134",
                12,
                12,
                12,
                VatRateType.Standard,
                12,
                "shipping time",
                "url",
                "imageUrl",
                "categoryTrail",
                new List<string>()));

            Assert.Equal(newName, product.Name);
        }

        [Fact]
        public void ShouldThrowWhenNewStockIsNegative()
        {
            var product = CreateProduct();

            Assert.Throws<BusinessLogicException>(() =>product.SetStock(-20));
        }

        [Fact]
        public void ShouldUpdateProductStock()
        {
            var product = CreateProduct();
            product.SetStock(20);

            Assert.Equal(20, product.Stock);
        }

        [Fact]
        public void ShouldUpdateProductUpdatedAtAfterUpdate()
        {
            var product = CreateProduct();
            var oldUpdatedAt = product.UpdatedAt;
            product.SetStock(20);

            Assert.NotEqual(oldUpdatedAt, product.UpdatedAt);
        }

        public Product CreateProduct() 
            => new ProductDomainFactory().Create(new ProductDataStructure(
                AggregateId.Generate(),
                true,
                new List<ProductExtraData>(),
                "Test",
                "Test",
                "Test",
                "test",
                "color",
                "ean",
                "134",
                12,
                12,
                12,
                VatRateType.Standard,
                12,
                "shipping time",
                "url",
                "imageUrl",
                "categoryTrail",
                new List<string>()));
    }
}
