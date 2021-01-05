using MediatR;
using Microsoft.Extensions.Logging;
using Recruitment.API.Utility;

namespace Recruitment.API.Infrastructure
{
    public interface IAppInjector
    {
        ILogger<AppLogger> Logger { get; set; }
        IMediator Mediator { get; set; }
    }
}
