using System.Runtime.Serialization;

namespace ChannelEngineAssessmentDomain.MerchantOrders
{
    public enum OrderLineCondition
    {
        [EnumMember(Value = "NEW")]
        New,
        [EnumMember(Value = "NEW_REFURBISHED")]
        NewRefurbished,
        [EnumMember(Value = "USED_AS_NEW")]
        UsedAsNew,
        [EnumMember(Value = "USED_GOOD")]
        UsedGood,
        [EnumMember(Value = "USED_REASONABLE")]
        UsedReasonable,
        [EnumMember(Value = "USED_MEDIOCRE")]
        UsedMediocre,
        [EnumMember(Value = "UNKNOWN")]
        Unknown,
        [EnumMember(Value = "USED_VERY_GOOD")]
        UsedVeryGood
    }
}