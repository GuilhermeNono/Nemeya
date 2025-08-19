using Idp.Application.Members.Abstractions.Commands;
using Idp.Contract.Authentication.Response;
using Idp.CrossCutting.Exceptions.Http.BadRequest;
using Idp.CrossCutting.Exceptions.Http.UnprocessableEntity.Client;
using Idp.Domain.Entities;
using Idp.Domain.Enums.Smart;
using Idp.Domain.Helpers;
using Idp.Domain.Repositories;

namespace Idp.Application.Members.Commands.Authentication.Authorize.Code;

public class CodeAuthorizeCommandHandler(
    IClientRepository clientRepository,
    IClientRedirectRepository clientRedirectRepository,
    IScopeRepository scopeRepository,
    IAuthorizationCodeRepository authorizationCodeRepository)
    : ICommandHandler<CodeAuthorizeCommand, CodeAuthorizeResponse>
{
    public async Task<CodeAuthorizeResponse> Handle(CodeAuthorizeCommand request, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(request.ClientId, out var clientId))
            throw new InvalidClientException(request.ClientId);

        if (!await clientRepository.Exists(clientId))
            throw new ClientNotFoundException();

        if (!await clientRedirectRepository.IsValidRedirect(clientId, request.RedirectUri))
            throw new Exception();

        var requestedScopes = request.Scopes.Split(' ');

        var scopes = (await scopeRepository.FindByNames(requestedScopes)).ToArray();

        if (scopes.Length != requestedScopes.Length)
            throw new Exception(); // Escopo inexistente

        await authorizationCodeRepository.Add(new AuthorizationCodeEntity
        {
            ClientId = clientId,
            Code = CryptoHelper.GenerateAuthorizationCode(),
            ExpiresAt = DateTimeOffset.Now.AddMinutes(1),
            IsUsed = false,
            CodeChallenge = request.CodeChallenge,
            State = request.State,
            UsedAt = null
        }, DefaultUserOperation.System, cancellationToken);

        //Modificar para a Url Correta
        return new CodeAuthorizeResponse($"{request.RedirectUri}");
    }
}