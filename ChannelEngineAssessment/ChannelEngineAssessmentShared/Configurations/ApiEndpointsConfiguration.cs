namespace ChannelEngineAssessmentShared.Configurations
{
    public class ApiEndpointsConfiguration : IApiEndpointsConfiguration
    {
        public string GetOrdersEndpoint { get; set; }
        public string SetProductEndpoint { get; set; }
        public string GetProductsEndpoint { get; set; }
        public string GetProductEndpoint { get; set; }

        public ApiEndpointsConfiguration()
        {

        }

        public ApiEndpointsConfiguration(string getOrdersEndpoint, string setProductEndpoint, string getProductsEndpoint, string getProductEndpoint)
        {
            GetOrdersEndpoint = getOrdersEndpoint;
            SetProductEndpoint = setProductEndpoint;
            GetProductsEndpoint = getProductsEndpoint;
            GetProductEndpoint = getProductEndpoint;
        }

    }
}