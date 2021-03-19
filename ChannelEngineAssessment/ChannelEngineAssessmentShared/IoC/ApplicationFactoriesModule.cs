using Autofac;
using ChannelEngineAssessmentShared.Domain;
using ChannelEngineAssessmentShared.Infrastructure.Factories;

namespace ChannelEngineAssessmentShared.IoC
{
    public class ApplicationFactoriesModule<TFactory> : Module where TFactory : IDomainFactory
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            var domainAssembly = typeof(TFactory).Assembly;

            builder.RegisterType<HttpClientFactory>().As<IHttpClientFactory>().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(domainAssembly).Where(x => x.IsAssignableTo<IDomainFactory>());
        }
    }
}