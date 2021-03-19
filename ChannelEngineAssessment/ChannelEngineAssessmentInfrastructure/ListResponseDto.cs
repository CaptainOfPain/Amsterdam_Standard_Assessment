using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelEngineAssessmentInfrastructure
{
    public class ListResponseDto<TDto>
    {
        public IEnumerable<TDto> Content { get; set; }
    }
}
