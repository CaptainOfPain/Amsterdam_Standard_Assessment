using System.Runtime.Serialization;

namespace ChannelEngineAssessmentDomain.Products
{
    public enum VatRateType
    {
        [EnumMember(Value = "STANDARD")]
        Standard = 1,
        [EnumMember(Value = "REDUCED")]
        Reduced = 2,
        [EnumMember(Value = "SUPER_REDUCED")]
        SuperReduced = 3,
        [EnumMember(Value = "EXEMPT")]
        Exempt = 4
    }
}