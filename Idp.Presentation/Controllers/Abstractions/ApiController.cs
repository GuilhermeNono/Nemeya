using Idp.Domain.Helpers;
using Idp.Domain.Interfaces;
using Idp.Domain.Objects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Idp.Presentation.Controllers.Abstractions;

[ApiController]
public abstract class ApiController : ControllerBase, IController
{
    protected readonly ISender Sender;
    protected ILogger<IController> Logger;

    protected ApiController(ISender sender, ILogger<IController> logger)
    {
        Sender = sender;
        Logger = logger;
    }

    
    public LoggedPerson LoggedPerson => JwtHelper.CreateAuthenticatedPerson(User);
}
