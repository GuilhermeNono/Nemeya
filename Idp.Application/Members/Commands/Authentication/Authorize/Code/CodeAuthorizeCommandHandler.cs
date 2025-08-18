using Idp.Application.Members.Abstractions.Commands;
using Idp.Contract.Authentication.Response;

namespace Idp.Application.Members.Commands.Authentication.Authorize.Code;

public class CodeAuthorizeCommandHandler : ICommandHandler<CodeAuthorizeCommand, CodeAuthorizeResponse>
{
    public Task<CodeAuthorizeResponse> Handle(CodeAuthorizeCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}