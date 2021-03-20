using Autofac;
using ChannelEngineAssessmentShared.Application.Handlers.Abstraction;
using ChannelEngineAssessmentShared.Application.Handlers.Implementations;
using ChannelEngineAssessmentShared.Application.Services;
using ChannelEngineAssessmentShared.Infrastructure.Abstractions;
using Module = Autofac.Module;

namespace ChannelEngineAssessmentShared.IoC 
{
    public class ApplicationHandlersModule<TService> : Module where TService : IService
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            var serviceAssembly = typeof(TService).Assembly;

            builder.RegisterAssemblyTypes(serviceAssembly)
                .Where(x => x.IsAssignableTo<IService>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(serviceAssembly)
                .Where(x => x.IsAssignableTo<IReadModel>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(serviceAssembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(serviceAssembly)
                .AsClosedTypesOf(typeof(IQueryHandler<,>))
                .InstancePerLifetimeScope();

            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>().InstancePerLifetimeScope();
            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>().InstancePerLifetimeScope();

            builder.RegisterType<CommandQueryDispatcherDecorator>().As<ICommandQueryDispatcherDecorator>().InstancePerLifetimeScope();
        }
    }
}
