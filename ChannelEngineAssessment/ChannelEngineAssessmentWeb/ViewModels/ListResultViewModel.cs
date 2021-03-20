using System.Collections.Generic;

namespace ChannelEngineAssessmentWeb.ViewModels
{
    public class ListResultViewModel<TViewModel>
    {
        public IEnumerable<TViewModel> Items { get; set; }
    }
}
