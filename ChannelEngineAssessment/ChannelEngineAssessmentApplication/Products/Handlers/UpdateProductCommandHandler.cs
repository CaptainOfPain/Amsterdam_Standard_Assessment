using System;
using System.Threading.Tasks;
using AutoMapper;
using ChannelEngineAssessmentDomain.Products.DataStructures;
using ChannelEngineAssessmentInfrastructure.Products.Commands;
using ChannelEngineAssessmentShared.Application.Handlers.Abstraction;

namespace ChannelEngineAssessmentApplication.Products.Handlers
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
    {
        private readonly IProductsService _productsService;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductsService productsService, IMapper mapper)
        {
            _productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task HandleAsync(UpdateProductCommand command)
        {
            await _productsService.UpdateAsync(_mapper.Map<ProductDataStructure>(command));
        }
    }
}