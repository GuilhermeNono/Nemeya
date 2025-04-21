using Idp.Domain.Annotations;
using Idp.Domain.Interfaces;
using Idp.Presentation.Controllers.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Idp.Presentation.Controllers;

[ApiRoute("auth")]
public class AuthenticationController : ApiController
{
    public AuthenticationController(ISender sender, ILogger<IController> logger) : base(sender, logger)
    {
    }

    [AllowAnonymous]
    [HttpPost("connect/token")]
    public IActionResult TestAuthentication()
    {
        return Ok();
    }

    [Authorize]
    [HttpPost("secure")]
    public IActionResult Secure()
    {
        return Ok();
    }
}