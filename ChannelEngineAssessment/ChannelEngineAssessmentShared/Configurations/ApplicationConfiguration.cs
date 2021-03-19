namespace ChannelEngineAssessmentShared.Configurations
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        public string BaseApiUrl { get; set; }
        public bool ThrowOnApiError { get; set; }
        public bool FailOnApiDeserializationError { get; set; }
        public string ApiKeyNameUrlParameter { get; set; }
        public string ApiKey { get; set; }
        public IApiEndpointsConfiguration Endpoints { get; set; }

        public ApplicationConfiguration()
        {

        }

        public ApplicationConfiguration(string baseApiUrl, bool throwOnApiError, bool failOnApiDeserializationError, string apiKeyNameUrlParameter, string apiKey, IApiEndpointsConfiguration endpoints)
        {
            BaseApiUrl = baseApiUrl;
            ThrowOnApiError = throwOnApiError;
            FailOnApiDeserializationError = failOnApiDeserializationError;
            ApiKeyNameUrlParameter = apiKeyNameUrlParameter;
            ApiKey = apiKey;
            Endpoints = endpoints;
        }
    }
}