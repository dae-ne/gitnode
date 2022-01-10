using System;

namespace GitNode.Application.Common.Exceptions
{
    public class ExternalApiException : Exception
    {
        public ExternalApiException(int code)
        {
            Code = code;
        }

        public ExternalApiException(int code, string message) : base(message)
        {
            Code = code;
        }

        public ExternalApiException(int code, string message, Exception inner) : base(message, inner)
        {
            Code = code;
        }
        
        public int Code { get; }
    }
}