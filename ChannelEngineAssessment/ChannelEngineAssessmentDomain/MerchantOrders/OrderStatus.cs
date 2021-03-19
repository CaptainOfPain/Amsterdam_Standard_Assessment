using System.Runtime.Serialization;

namespace ChannelEngineAssessmentDomain.MerchantOrders
{
    public enum OrderStatus
    {
        [EnumMember(Value = "NEW")]
        New = 1,
        [EnumMember(Value = "IN_PROGRESS")]
        InProgress = 2,
        [EnumMember(Value = "SHIPPED")]
        Shipped = 3,
        [EnumMember(Value = "MANCO")]
        Manco = 4,
        [EnumMember(Value = "IN_BACKORDER")]
        InBackorder = 5,
        [EnumMember(Value = "IN_COMBI")]
        InCombi = 6,
        [EnumMember(Value = "REQUIRES_CORRECTION")]
        RequiresCorrection = 7,
        [EnumMember(Value = "RETURNED")]
        Returned = 8,
        [EnumMember(Value = "CLOSED")]
        Closed = 9,
        [EnumMember(Value = "CANCELED")]
        Canceled = 10,
    }
}