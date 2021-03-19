namespace ChannelEngineAssessmentDomain.Products
{
    public readonly struct ProductExtraData
    {
        public string Key { get; }
        public string Value { get; }
        public ProductExtraDataType Type { get; }
        public bool IsPublic { get; }

        public ProductExtraData(string key, string value, ProductExtraDataType type, bool isPublic)
        {
            Key = key;
            Value = value;
            Type = type;
            IsPublic = isPublic;
        }
    }
}