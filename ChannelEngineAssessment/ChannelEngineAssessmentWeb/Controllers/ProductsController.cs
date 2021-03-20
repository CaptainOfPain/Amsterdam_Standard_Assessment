using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChannelEngineAssessmentDomain.Products;
using ChannelEngineAssessmentInfrastructure;
using ChannelEngineAssessmentInfrastructure.Products.Commands;
using ChannelEngineAssessmentInfrastructure.Products.DTOs;
using ChannelEngineAssessmentInfrastructure.Products.Queries;
using ChannelEngineAssessmentShared.Application.Handlers.Abstraction;
using ChannelEngineAssessmentShared.Domain;
using ChannelEngineAssessmentWeb.ViewModels;
using ChannelEngineAssessmentWeb.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;

namespace ChannelEngineAssessmentWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : BaseController
    {
        public ProductsController(IMapper mapper, ICommandQueryDispatcherDecorator commandQueryDispatcherDecorator) : base(mapper, commandQueryDispatcherDecorator)
        {
        }

        [HttpGet("{merchantOrderNo}")]
        public async Task<IActionResult> Get(string merchantOrderNo) 
        {
            var query = new GetProductQuery(new AggregateId(merchantOrderNo));
            var result = await CommandQueryDispatcherDecorator.DispatchAsync<GetProductQuery, ProductDto>(query);

            return Ok(Mapper.Map<ProductViewModel>(result));
        }

        [HttpGet("topSold")]
        public async Task<IActionResult> GetTopSoldProductsAsync()
        {
            var query = new GetTopSoldProductsQuery();
            var result = await CommandQueryDispatcherDecorator.DispatchAsync<GetTopSoldProductsQuery, ListResultDto<TopSoldProductDto>>(query);

            return Ok(Mapper.Map<ListResultViewModel<TopSoldProductViewModel>>(result));
        }

        [HttpPatch]
        public async Task<IActionResult> SetNewStockAsync([FromBody] SetProductNewStockViewModel viewModel)
        {
            var command = new SetProductStockCommand(new AggregateId(viewModel.MerchantProductNo), viewModel.NewStock);
            await CommandQueryDispatcherDecorator.DispatchAsync(command);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] SaveProductViewModel viewModel)
        {
            var command = new CreateProductCommand(
                new AggregateId(viewModel.MerchantProductNo),
                viewModel.IsActive,
                viewModel.ExtraData.Select(x => new ProductExtraData(x.Key, x.Value, x.Type, x.IsPublic)),
                viewModel.Name,
                viewModel.Description,
                viewModel.Brand,
                viewModel.Size, 
                viewModel.Color,
                viewModel.Ean,
                viewModel.ManufacturerProductNumber,
                viewModel.Price, 
                viewModel.MSRP,
                viewModel.PurchasePrice,
                viewModel.VatRateType,
                viewModel.ShippingCost,
                viewModel.ShippingTime,
                viewModel.Url,
                viewModel.ImageUrl,
                viewModel.CategoryTrail,
                viewModel.ExtraImageUrls
                );

            await CommandQueryDispatcherDecorator.DispatchAsync(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] SaveProductViewModel viewModel)
        {
            var command = new UpdateProductCommand(
                new AggregateId(viewModel.MerchantProductNo),
                viewModel.IsActive,
                viewModel.ExtraData.Select(x => new ProductExtraData(x.Key, x.Value, x.Type, x.IsPublic)),
                viewModel.Name,
                viewModel.Description,
                viewModel.Brand,
                viewModel.Size,
                viewModel.Color,
                viewModel.Ean,
                viewModel.ManufacturerProductNumber,
                viewModel.Price,
                viewModel.MSRP,
                viewModel.PurchasePrice,
                viewModel.VatRateType,
                viewModel.ShippingCost,
                viewModel.ShippingTime,
                viewModel.Url,
                viewModel.ImageUrl,
                viewModel.CategoryTrail,
                viewModel.ExtraImageUrls
            );

            await CommandQueryDispatcherDecorator.DispatchAsync(command);
            return Ok();
        }
    }
}
