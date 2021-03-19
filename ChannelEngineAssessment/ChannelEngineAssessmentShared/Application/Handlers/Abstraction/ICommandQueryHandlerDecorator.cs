using System.Threading.Tasks;
using ChannelEngineAssessmentShared.Infrastructure.Abstractions;

namespace ChannelEngineAssessmentShared.Application.Handlers.Abstraction
{
    public interface ICommandQueryHandlerDecorator
    {
        Task DispatchAsync<TCommand>(TCommand command) where TCommand : ICommand;
        Task<TDto> DispatchAsync<TQuery, TDto>(TQuery query) where TQuery : IQuery where TDto : IDto;
    }
}