using System;
using AutoMapper;
using ChannelEngineAssessmentShared.Application.Handlers.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace ChannelEngineAssessmentWeb.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMapper Mapper;
        protected readonly ICommandQueryDispatcherDecorator CommandQueryDispatcherDecorator;

        protected BaseController(IMapper mapper, ICommandQueryDispatcherDecorator commandQueryDispatcherDecorator)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            CommandQueryDispatcherDecorator = commandQueryDispatcherDecorator ?? throw new ArgumentNullException(nameof(commandQueryDispatcherDecorator));
        }
    }
}