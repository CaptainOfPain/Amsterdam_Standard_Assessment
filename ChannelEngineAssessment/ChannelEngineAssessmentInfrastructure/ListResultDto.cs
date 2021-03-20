using System.Collections.Generic;
using ChannelEngineAssessmentShared.Infrastructure.Abstractions;

namespace ChannelEngineAssessmentInfrastructure
{
    public class ListResultDto<TDto> : IDto
    {
        public ListResultDto(IEnumerable<TDto> items)
        {
            Items = items;
        }

        public IEnumerable<TDto> Items { get; }
    }
}