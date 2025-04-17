using Idp.Domain.Annotations;
using Idp.Domain.Interfaces;
using Idp.Presentation.Controllers.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Idp.Presentation.Controllers;

[ApiRoute("test")]
public class TestController : ApiController
{
    public TestController(ISender sender, ILogger<IController> logger) : base(sender, logger)
    {
    }

    [HttpGet]
    public Task<IActionResult> TestAction()
    {
        return Task.FromResult<IActionResult>(Ok());
    }
}