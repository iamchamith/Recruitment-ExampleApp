using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text;

//https://docs.microsoft.com/en-us/azure/azure-functions/functions-test-a-function
namespace Recuitment.Tests.Utility
{
    public class TestFactory
    {
        public static IEnumerable<object[]> Data()
        {
            return new List<object[]>
            {
                new object[] { "name", "Bill" },
                new object[] { "name", "Paul" },
                new object[] { "name", "Steve" }

            };
        }

        private static Stream StringToStream(string value)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(value);
            //byte[] byteArray = Encoding.ASCII.GetBytes(contents);
            return new MemoryStream(byteArray);
        }

        public static HttpRequest CreateCommandHttpRequest(string value)
        {
            var context = new DefaultHttpContext();
            var request = context.Request;
            request.Body = StringToStream(value);
            return request;
        }

        public static ILogger CreateLogger(LoggerTypes type = LoggerTypes.Null)
        {
            ILogger logger;

            if (type == LoggerTypes.List)
            {
                logger = new ListLogger();
            }
            else
            {
                logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");
            }

            return logger;
        }
        public enum LoggerTypes
        {
            Null,
            List
        }
    }
}
