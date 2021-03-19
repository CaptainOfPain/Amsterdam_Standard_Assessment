namespace ChannelEngineAssessmentShared.Configurations
{
    public interface IApplicationConfiguration
    {
        string BaseApiUrl { get; }
        bool ThrowOnApiError { get; }
        bool FailOnApiDeserializationError { get; }
        string ApiKeyNameUrlParameter { get; }
        string ApiKey { get; }
        IApiEndpointsConfiguration Endpoints { get; }
    }
}
