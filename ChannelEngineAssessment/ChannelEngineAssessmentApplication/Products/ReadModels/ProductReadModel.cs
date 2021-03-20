using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChannelEngineAssessmentInfrastructure;
using ChannelEngineAssessmentInfrastructure.MerchantOrders.Repositories;
using ChannelEngineAssessmentInfrastructure.Products.DTOs;
using ChannelEngineAssessmentInfrastructure.Products.Queries;
using ChannelEngineAssessmentInfrastructure.Products.Repositories;
using ChannelEngineAssessmentShared.Domain;

namespace ChannelEngineAssessmentApplication.Products.ReadModels
{
    public class ProductReadModel : IProductReadModel
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMerchantOrderRepository _merchantOrderRepository;
        private readonly IMapper _mapper;

        public ProductReadModel(IProductsRepository productsRepository, IMerchantOrderRepository merchantOrderRepository, IMapper mapper)
        {
            _productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
            _merchantOrderRepository = merchantOrderRepository ?? throw new ArgumentNullException(nameof(merchantOrderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ProductDto> GetProductAsync(GetProductQuery query)
        {
            var product = await _productsRepository.GetAsync(query.MerchantProductNo);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ListResultDto<TopSoldProductDto>> GetTopSoldProducts(GetTopSoldProductsQuery query)
        {
            var orders = await _merchantOrderRepository.BrowseAsync(query.OrderStatuses);
            var ordersProductNos = orders.SelectMany(x => x.Lines).Select(x => x.MerchantProductNo).Distinct().ToList();

            var productsQuantities = new Dictionary<AggregateId, int>();
            foreach (var ordersProductNo in ordersProductNos)
            {
                var lines = orders.SelectMany(x => x.Lines).Where(x => x.MerchantProductNo.Equals(ordersProductNo));
                productsQuantities.Add(ordersProductNo, lines.Sum(x => x.Quantity));
            }

            var products = await _productsRepository.BrowseAsync(ordersProductNos.Select(x => x.Id));

            return new ListResultDto<TopSoldProductDto>(products.Select(p => new TopSoldProductDto()
            {
                MerchantProductNo = p.Id,
                EAN = p.Ean,
                Name = p.Name,
                TotalQuantity = productsQuantities[p.Id]
            }).OrderByDescending(x => x.TotalQuantity).Take(query.TopProductsNumber));
        }
    }
}