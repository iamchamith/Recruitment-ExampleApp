using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text;

namespace Recruitment.Functions
{
    public static class IdentityFunction
    {
        [FunctionName("Login")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation("C# HTTP trigger function processed a request.");

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                if (string.IsNullOrEmpty(requestBody))
                    return new BadRequestObjectResult("Invalid username or password");
                var sb = new StringBuilder();
                using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
                {
                    byte[] inputBytes = Encoding.ASCII.GetBytes(requestBody);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        sb.Append(hashBytes[i].ToString("X2"));
                    }
                }
                return new OkObjectResult(sb.ToString());
            }
            catch (System.Exception ex)
            {
                log.LogInformation(ex, "Login");
                return new StatusCodeResult(500);
            }
           
        }
    }
}
