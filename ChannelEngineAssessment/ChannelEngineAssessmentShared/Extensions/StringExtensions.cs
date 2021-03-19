using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace ChannelEngineAssessmentShared.Extensions
{
    public static class StringExtensions
    {
        public static string ValidateStringLength(this string value, int maxLength, string name)
        {
            if (!string.IsNullOrWhiteSpace(value) && value.Length > maxLength)
            {
                throw new ArgumentException(name);
            }

            return value;
        }
    }

    public static class EnumExtensions
    {
        public static string GetEnumMemberValue<T>(this T value) where T : Enum
            => typeof(T)
                .GetTypeInfo()
                .DeclaredMembers
                .SingleOrDefault(x => x.Name == value.ToString())
                ?.GetCustomAttribute<EnumMemberAttribute>(false)
                ?.Value;
    }
}
