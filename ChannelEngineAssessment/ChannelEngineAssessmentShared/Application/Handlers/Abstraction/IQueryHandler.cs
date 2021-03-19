using System.Threading.Tasks;
using ChannelEngineAssessmentShared.Infrastructure.Abstractions;

namespace ChannelEngineAssessmentShared.Application.Handlers.Abstraction
{
    public interface IQueryHandler<in TQuery, TDto> where TQuery : IQuery where TDto : IDto
    {
        Task<TDto> HandleAsync(TQuery query);
    }
}