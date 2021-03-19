namespace ChannelEngineAssessmentInfrastructure.Products.DTOs
{
    public class ProductExtraDataDto
    {
        public string Key { get; }
        public string Value { get; }
        public string Type { get; }
        public bool IsPublic { get; }

        public ProductExtraDataDto(string key, string value, string type, bool isPublic)
        {
            Key = key;
            Value = value;
            Type = type;
            IsPublic = isPublic;
        }
    }
}