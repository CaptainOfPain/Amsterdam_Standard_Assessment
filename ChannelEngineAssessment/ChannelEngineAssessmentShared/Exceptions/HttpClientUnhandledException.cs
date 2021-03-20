using System;
using System.Net;

namespace ChannelEngineAssessmentShared.Exceptions
{
    public class HttpClientUnhandledException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public HttpClientUnhandledException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}