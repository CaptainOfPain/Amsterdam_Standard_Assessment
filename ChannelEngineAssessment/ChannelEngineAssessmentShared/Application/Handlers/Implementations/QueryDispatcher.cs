using System;
using System.Threading.Tasks;
using Autofac;
using ChannelEngineAssessmentShared.Application.Handlers.Abstraction;
using ChannelEngineAssessmentShared.Infrastructure.Abstractions;

namespace ChannelEngineAssessmentShared.Application.Handlers.Implementations
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IComponentContext _context;

        public QueryDispatcher(IComponentContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<TDto> DispatchAsync<TQuery, TDto>(TQuery query) where TQuery : IQuery where TDto : IDto
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var handler = _context.Resolve<IQueryHandler<TQuery, TDto>>();
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return handler.HandleAsync(query);
        }
    }
}