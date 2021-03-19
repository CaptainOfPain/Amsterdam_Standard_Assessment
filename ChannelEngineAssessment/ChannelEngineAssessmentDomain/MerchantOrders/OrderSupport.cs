using System.Runtime.Serialization;

namespace ChannelEngineAssessmentDomain.MerchantOrders
{
    public enum OrderSupport
    {
        [EnumMember(Value = "NONE")]
        None = 1,
        [EnumMember(Value = "ORDERS")]
        Orders = 2,
        [EnumMember(Value = "SPLIT_ORDERS")]
        SplitOrders = 3,
        [EnumMember(Value = "SPLIT_ORDER_LINES")]
        SplitOrderLines = 4
    }
}