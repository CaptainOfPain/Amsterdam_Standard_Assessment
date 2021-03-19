using System;

namespace ChannelEngineAssessmentShared.Exceptions
{
    public class HttpClientUnhandledException : Exception
    {
        public HttpClientUnhandledException(string message) : base(message)
        {
        }
    }
}