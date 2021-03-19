using System;
using ChannelEngineAssessmentShared.Configurations;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace ChannelEngineAssessmentShared.Infrastructure.Factories
{
    public class HttpClientFactory : IHttpClientFactory
    {
        private readonly IApplicationConfiguration _applicationConfiguration;

        public HttpClientFactory(IApplicationConfiguration applicationConfiguration)
        {
            _applicationConfiguration = applicationConfiguration ?? throw new ArgumentNullException(nameof(applicationConfiguration));
        }


        public IRestClient CreateRestClient()
        {
            var client = new RestClient(_applicationConfiguration.BaseApiUrl)
            {
                ThrowOnAnyError = _applicationConfiguration.ThrowOnApiError,
                FailOnDeserializationError = _applicationConfiguration.FailOnApiDeserializationError
            };
            client.UseNewtonsoftJson();

            return client;
        }
    }
}