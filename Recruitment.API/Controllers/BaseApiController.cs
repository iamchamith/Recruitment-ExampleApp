using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recruitment.API.Infrastructure;
using Recruitment.API.Utility;
using System;
using System.Threading.Tasks;

namespace Recruitment.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly ILogger _logger;
        public BaseApiController(IAppInjector injector)
        {
            _mediator = injector.Mediator;
            _logger = injector.Logger;
        }
        protected virtual IActionResult ExceptionHandler(Exception ex)
        {
            var baseEx = ex.GetBaseException();
            ObjectResult response = null;
            if (baseEx is AuthenticationException)
            {
                var e = (AuthenticationException)baseEx;
                response = e.HttpStatusCode == System.Net.HttpStatusCode.BadRequest ?
                    BadRequest(e.Message) : AppSettings.Environment == Enums.ApplicationEnvironment.Staging ?
                    StatusCode(500, ex.Message) : StatusCode(500, "Something went wrong");
            }
            if (response != null)
            {
                if (response.StatusCode == 500)
                    _logger.LogError(response.Value.ToString());
            }
            return StatusCode(500, "Something went wrong");
        }
    }
}
