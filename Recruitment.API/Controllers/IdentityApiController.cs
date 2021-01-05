using Microsoft.AspNetCore.Mvc;
using Recruitment.API.Infrastructure;
using Recruitment.API.Utility;
using Recruitment.Contracts;
using System.Threading.Tasks;

namespace Recruitment.API.Controllers
{
    public class IdentityApiController : BaseApiController
    {
        public IdentityApiController(IAppInjector appInjector) : base(appInjector)
        {
        }

        [HttpPost("hash"), ModelValidation]
        public async Task<IActionResult> Login([FromBody] LoginRequestCommand model)
        {
            try
            {
                var result = await _mediator.Send(model);
                return Ok(result);
            }
            catch (System.Exception e)
            {
                return ExceptionHandler(e);
            }

        }
    }
}
