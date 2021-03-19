using System.Threading.Tasks;
using ChannelEngineAssessmentShared.Infrastructure.Abstractions;

namespace ChannelEngineAssessmentShared.Application.Handlers.Abstraction
{
    public interface IQueryDispatcher
    {
        Task<TDto> DispatchAsync<TQuery, TDto>(TQuery query) where TQuery : IQuery where TDto : IDto;
    }
}