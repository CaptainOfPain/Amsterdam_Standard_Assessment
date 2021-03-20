namespace ChannelEngineAssessmentInfrastructure.Products.Requests
{
    public class ProductExtraDataRequest
    {
        public string Key { get; }
        public string Value { get; }
        public string Type { get; }
        public bool IsPublic { get; }

        public ProductExtraDataRequest(string key, string value, string type, bool isPublic)
        {
            Key = key;
            Value = value;
            Type = type;
            IsPublic = isPublic;
        }
    }
}