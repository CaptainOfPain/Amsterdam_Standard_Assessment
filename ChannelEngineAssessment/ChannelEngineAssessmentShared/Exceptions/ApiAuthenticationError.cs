using System;

namespace ChannelEngineAssessmentShared.Exceptions
{
    public class ApiAuthenticationError : Exception
    {
        public ApiAuthenticationError(string message) : base(message)
        {
        }
    }
}
