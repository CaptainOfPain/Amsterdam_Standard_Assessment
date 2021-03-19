namespace ChannelEngineAssessmentShared.Configurations
{
    public interface IApiEndpointsConfiguration
    {
        string GetOrdersEndpoint { get; }
        string SetProductEndpoint { get; }
        string GetProductsEndpoint { get; }
        string GetProductEndpoint { get; }
        string DeleteProductEndpoint { get; }
    }
}