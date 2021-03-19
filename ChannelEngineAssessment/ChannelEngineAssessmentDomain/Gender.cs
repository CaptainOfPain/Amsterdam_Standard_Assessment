using System.Runtime.Serialization;

namespace ChannelEngineAssessmentDomain
{
    public enum Gender
    {
        [EnumMember(Value = "MALE")]
        Male = 1,
        [EnumMember(Value = "FEMALE")]
        Female = 2,
        [EnumMember(Value = "NOT_APPLICABLE")]
        NotApplicable = 3
    }
}