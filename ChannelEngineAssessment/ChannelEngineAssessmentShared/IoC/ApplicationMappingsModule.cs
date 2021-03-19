using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using AutoMapper;
using Module = Autofac.Module;

namespace ChannelEngineAssessmentShared.IoC
{
    public class ApplicationMappingsModule : Module
    {
        private readonly Assembly[] _assemblies;

        public ApplicationMappingsModule(params Assembly[] assemblies)
        {
            _assemblies = assemblies ?? throw new ArgumentNullException(nameof(assemblies));
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.Register(ctx =>
            {
                var profiles = new List<Profile>();

                foreach (var assembly in _assemblies)
                {
                    profiles.AddRange(assembly.DefinedTypes.Where(x => TypeExtensions.IsAssignableTo<Profile>(x)).Select(x => Activator.CreateInstance(x) as Profile));
                }

                var mapperConfig = new MapperConfiguration(x =>
                {
                    x.DisableConstructorMapping();
                    x.AddProfiles(profiles);
                });


                return mapperConfig.CreateMapper();
            }).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}