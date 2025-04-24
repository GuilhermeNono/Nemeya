using Idp.Domain.Annotations;
using Idp.Domain.Interfaces;
using Idp.Presentation.Controllers.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenIddict.Abstractions;

namespace Idp.Presentation.Controllers;

[ApiRoute("auth")]
public class AuthenticationController : ApiController
{
    public AuthenticationController(ISender sender, ILogger<IController> logger) : base(sender, logger)
    {
    }

    [AllowAnonymous]
    [HttpPost("connect/token")]
    public async Task<IActionResult> TestAuthentication()
    {
        return Ok();
    }

    [Authorize]
    [HttpPost("secure")]
    public async Task<IActionResult> Secure()
    {
        return Ok();
    }
}