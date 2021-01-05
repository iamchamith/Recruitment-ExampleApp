using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Recruitment.Contracts;
using Recruitment.Functions;
using Recuitment.Tests.Utility;
using Xunit;
namespace Recuitment.Tests
{
    public class IdentityFunctionUnitTest
    {
        private readonly ILogger logger = TestFactory.CreateLogger();


        [Theory]
        [InlineData("hasitha", "123", "575AD95D46FAFF2D0C56AAEFFCD30884")]
        [InlineData("nuwan", "456", "BF1D76B5ED8624B9A905AF7863A641F8")]
        public async void Http_trigger_should_return_known_hash(string username, string password, string hash)
        {
            var body = JsonConvert.SerializeObject(new LoginRequestCommand
            {
                UserName = username,
                Password = password
            });
            var request = TestFactory.CreateCommandHttpRequest(body);
            var response = (OkObjectResult)await IdentityFunction.Run(request, logger);
            Assert.Equal(hash, response.Value);
        }
    }
}
