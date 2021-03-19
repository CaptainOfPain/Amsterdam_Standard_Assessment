using System;
using System.Threading.Tasks;
using ChannelEngineAssessmentShared.Application.Handlers.Abstraction;
using ChannelEngineAssessmentShared.Infrastructure.Abstractions;

namespace ChannelEngineAssessmentShared.Application.Handlers.Implementations
{
    public class CommandQueryHandlerDecorator : ICommandQueryHandlerDecorator
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public CommandQueryHandlerDecorator(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher ?? throw new ArgumentNullException(nameof(commandDispatcher));
            _queryDispatcher = queryDispatcher ?? throw new ArgumentNullException(nameof(queryDispatcher));
        }

        public Task DispatchAsync<TCommand>(TCommand command) where TCommand : ICommand
            => _commandDispatcher.DispatchAsync(command);

        public Task<TDto> DispatchAsync<TQuery, TDto>(TQuery query) where TQuery : IQuery where TDto : IDto
            => _queryDispatcher.DispatchAsync<TQuery, TDto>(query);
    }
}