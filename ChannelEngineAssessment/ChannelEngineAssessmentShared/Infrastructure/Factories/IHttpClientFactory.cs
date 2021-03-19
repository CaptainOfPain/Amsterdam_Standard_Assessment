using System.Collections.Generic;
using System.Text;
using RestSharp;

namespace ChannelEngineAssessmentShared.Infrastructure.Factories
{
    public interface IHttpClientFactory
    {
        IRestClient CreateRestClient();
    }
}
