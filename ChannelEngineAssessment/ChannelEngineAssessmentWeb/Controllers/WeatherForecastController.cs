using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChannelEngineAssessmentInfrastructure.MerchantOrders.Repositories;

namespace ChannelEngineAssessmentWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMerchantOrderRepository _merchantOrderRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMerchantOrderRepository merchantOrderRepository)
        {
            _logger = logger;
            _merchantOrderRepository = merchantOrderRepository ?? throw new ArgumentNullException(nameof(merchantOrderRepository));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _merchantOrderRepository.GetAllAsync());
        }
    }
}
