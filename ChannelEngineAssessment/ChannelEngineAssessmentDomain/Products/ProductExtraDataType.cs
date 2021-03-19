using System.Runtime.Serialization;

namespace ChannelEngineAssessmentDomain.Products
{
    public enum ProductExtraDataType
    {
        [EnumMember(Value = "TEXT")]
        Text = 1,
        [EnumMember(Value = "NUMBER")]
        Number = 2,
        [EnumMember(Value = "URL")]
        Url = 3,
        [EnumMember(Value = "IMAGEURL")]
        ImageUrl = 4
    }
}