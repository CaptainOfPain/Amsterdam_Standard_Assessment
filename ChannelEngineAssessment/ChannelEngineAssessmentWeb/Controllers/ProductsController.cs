using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using ChannelEngineAssessmentInfrastructure;
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
    }
}
