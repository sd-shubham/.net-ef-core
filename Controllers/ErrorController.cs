using System;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPIAndEfCore.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/local-development")]
        public IActionResult HandleDevelopmentPhaseError([FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.EnvironmentName != "Development")
                throw new InvalidOperationException($"invalid {webHostEnvironment} environment");
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            return Problem(
                detail: context.Error.StackTrace,
                title: context.Error?.InnerException?.Message ?? context.Error.Message
            );
        }
        [Route("/error")]
        public IActionResult HandleProductionError() => Problem();
    }
}