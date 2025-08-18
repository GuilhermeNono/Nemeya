using Idp.Application.Members.Abstractions.Commands;
using Idp.Contract.Authentication.Request;
using Idp.Contract.Authentication.Response;
using Idp.Contract.Enum;
using Idp.Domain.Objects;

namespace Idp.Application.Members.Commands.Authentication.Authorize.Code;

public record CodeAuthorizeCommand(
    ResponseType ResponseType,
    string ClientId,
    string RedirectUri,
    string Scopes,
    string State,
    string CodeChallenge,
    CodeChallengeMethod CodeChallengeMethod,
    LoggedPerson LoggedPerson) : ICommand<CodeAuthorizeResponse>
{
    public static CodeAuthorizeCommand ToCommand(CodeAuthorizeRequest request, LoggedPerson loggedPerson)
    {
        return new CodeAuthorizeCommand(request.ResponseType, request.ClientId, request.RedirectUri, request.Scopes, request.State,
            request.CodeChallenge, request.CodeChallengeMethod, loggedPerson);
    }
}