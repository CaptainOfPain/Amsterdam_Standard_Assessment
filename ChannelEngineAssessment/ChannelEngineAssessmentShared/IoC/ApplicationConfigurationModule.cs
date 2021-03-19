using System;
using Autofac;
using ChannelEngineAssessmentShared.Configurations;

namespace ChannelEngineAssessmentShared.IoC
{
    public class ApplicationConfigurationModule : Module
    {
        private readonly IApplicationConfiguration _applicationConfiguration;

        public ApplicationConfigurationModule(IApplicationConfiguration applicationConfiguration)
        {
            _applicationConfiguration = applicationConfiguration ?? throw new ArgumentNullException(nameof(applicationConfiguration));
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.Register(ctx => _applicationConfiguration).As<IApplicationConfiguration>().SingleInstance();
        }
    }
}