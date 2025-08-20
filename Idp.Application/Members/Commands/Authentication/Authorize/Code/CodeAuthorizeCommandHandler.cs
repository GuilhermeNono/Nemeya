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
        if (!Ulid.TryParse(request.ClientId, out var clientId))
            throw new InvalidClientException(request.ClientId);
        
        var client = await clientRepository.FindByClientId(clientId.ToString()) 
                     ?? throw new ClientNotFoundException();

        if (!await clientRedirectRepository.IsValidRedirect(client.Id, request.RedirectUri))
            throw new Exception();

        var requestedScopes = request.Scopes.Split(' ');

        var scopes = new List<ScopeEntity>();
        
        foreach (var scope in requestedScopes)
        {
            var value = await scopeRepository.FindByNames(scope);
            if (value == null)
                continue;
            scopes.Add(value);
        }

        if (scopes.Count != requestedScopes.Length)
            throw new Exception(); // Escopo inexistente

        await authorizationCodeRepository.Add(new AuthorizationCodeEntity
        {
            ClientId = client.Id,
            UserId = null,
            Code = CryptoHelper.GenerateAuthorizationCode(),
            ExpiresAt = DateTimeOffset.Now.AddMinutes(1),
            IsUsed = false,
            CodeChallenge = request.CodeChallenge,
            State = request.State,
            UsedAt = null
        }, DefaultUserOperation.System, cancellationToken);

        //Modificar para a Url Correta
        return new CodeAuthorizeResponse(request.RedirectUri, new ParamsWrapper(new Dictionary<string, string>
        {
            { "scopes", string.Join('-', request.Scopes.Split(' ')) },
            { "clientid", request.ClientId},
            { "response_type", request.ResponseType.ToString() },
            {"state", request.State },
            {"code_challenge", request.CodeChallenge},
            {"code_challenge_method", request.CodeChallengeMethod.ToString() },
        }));
    }
}