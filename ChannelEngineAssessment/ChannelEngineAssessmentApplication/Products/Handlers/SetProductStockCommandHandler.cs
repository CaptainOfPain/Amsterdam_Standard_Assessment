using System;
using System.Threading.Tasks;
using ChannelEngineAssessmentInfrastructure.Products.Commands;
using ChannelEngineAssessmentShared.Application.Handlers.Abstraction;

namespace ChannelEngineAssessmentApplication.Products.Handlers
{
    public class SetProductStockCommandHandler : ICommandHandler<SetProductStockCommand>
    {
        private readonly IProductsService _productsService;

        public SetProductStockCommandHandler(IProductsService productsService)
        {
            _productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
        }

        public async Task HandleAsync(SetProductStockCommand command)
        {
            await _productsService.SetStockAsync(command.MerchantProductNo, command.NewStock);
        }
    }
}