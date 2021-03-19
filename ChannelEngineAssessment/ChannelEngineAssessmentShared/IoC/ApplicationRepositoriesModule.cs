using Autofac;
using ChannelEngineAssessmentShared.Infrastructure.Repositories.Abstractions;
using ChannelEngineAssessmentShared.Infrastructure.Repositories.Implementations;

namespace ChannelEngineAssessmentShared.IoC
{
    public class ApplicationRepositoriesModule<TRepository> : Module where TRepository : IRepository
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            var repositoryAssembly = typeof(TRepository).Assembly;

            builder.RegisterAssemblyTypes(repositoryAssembly)
                .AsClosedTypesOf(typeof(IGenericRepository<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<GenericRestRepository>().As<IGenericRestRepository>().InstancePerLifetimeScope();
        }
    }
}