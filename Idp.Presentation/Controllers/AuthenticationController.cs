﻿using Idp.Application.Members.Commands.Authentication.Authorize.Code;
using Idp.Contract.Authentication.Request;
using Idp.Domain.Annotations;
using Idp.Domain.Enums;
using Idp.Domain.Interfaces;
using Idp.Presentation.Controllers.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Idp.Presentation.Controllers;

[ApiRoute("auth", ApiRouteVersion.Version1)]
public class AuthenticationController : ApiController
{
    public AuthenticationController(ISender sender, ILogger<IController> logger) : base(sender, logger)
    {
    }

    [AllowAnonymous]
    [HttpPost("authorize")]
    [Consumes("application/x-www-form-urlencoded")]
    [Produces("application/json")]
    public async Task<IActionResult> AuthorizeWithCodeChallengeAsync([FromForm]CodeAuthorizeRequest request)
    {
        return Ok(await Sender.Send(CodeAuthorizeCommand.ToCommand(request, LoggedPerson)));
    }
}