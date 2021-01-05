using System;
using System.Net;
using System.Net.Http;

namespace Recruitment.API.Utility
{
    public class AuthenticationException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public AuthenticationException(HttpResponseMessage message) : base(message.StatusCode ==
            HttpStatusCode.BadRequest ? "Invalid username or password" : "Something went wrong")
        {
            HttpStatusCode = message.StatusCode;
        }
        public AuthenticationException() : base("Something went wrong")
        {
            HttpStatusCode = HttpStatusCode.InternalServerError;
        }
    }
}
