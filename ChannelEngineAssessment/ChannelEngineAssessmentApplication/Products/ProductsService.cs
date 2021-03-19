using System;
using System.Threading.Tasks;
using ChannelEngineAssessmentDomain.Products;
using ChannelEngineAssessmentDomain.Products.DataStructures;
using ChannelEngineAssessmentDomain.Products.Factories;
using ChannelEngineAssessmentDomain.Products.Resources;
using ChannelEngineAssessmentInfrastructure.Products.Repositories;
using ChannelEngineAssessmentShared.Domain;
using ChannelEngineAssessmentShared.Exceptions;

namespace ChannelEngineAssessmentApplication.Products
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IProductDomainFactory _productDomainFactory;

        public ProductsService(IProductsRepository productsRepository, IProductDomainFactory productDomainFactory)
        {
            _productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
            _productDomainFactory = productDomainFactory ?? throw new ArgumentNullException(nameof(productDomainFactory));
        }

        public async Task CreateAsync(ProductDataStructure productDataStructure)
        {
            var product = await _productsRepository.GetAsync(productDataStructure.MerchantProductNo);
            if (product != null)
            {
                throw new BusinessLogicException(ProductResources.ProductAlreadyExistsMessage);
            }
            product = _productDomainFactory.Create(productDataStructure);

            await _productsRepository.CreateAsync(product);
        }

        public async Task UpdateAsync(ProductDataStructure productDataStructure)
        {
            var product = await GetProductOrThrow(productDataStructure.MerchantProductNo);
            product.Update(productDataStructure);

            await _productsRepository.UpdateAsync(product);
        }

        public async Task SetStockAsync(AggregateId id, int newStock)
        {
            var product = await GetProductOrThrow(id);
            product.SetStock(newStock);

            await _productsRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(AggregateId id)
        {
            var product = await GetProductOrThrow(id);

            await _productsRepository.DeleteAsync(product.Id);
        }

        private async Task<Product> GetProductOrThrow(AggregateId id)
        {
            var product = await _productsRepository.GetAsync(id);
            if (product == null)
            {
                throw new BusinessLogicException(ProductResources.ProductNotFoundMessage);
            }

            return product;
        }
    }
}
