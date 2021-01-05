using MediatR;
using Microsoft.Extensions.Logging;
using Recruitment.API.Utility;

namespace Recruitment.API.Infrastructure
{
    public class AppInjector : IAppInjector
    {
        public ILogger<AppLogger> Logger { get; set; }
        public IMediator Mediator { get; set; }

        public AppInjector(ILogger<AppLogger> logger, IMediator mediator)
        {
            Logger = logger;
            Mediator = mediator;
        }
    }
}
