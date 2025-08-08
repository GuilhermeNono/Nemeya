using Idp.Domain.Entities;
using Idp.Domain.Enums.Smart;
using Idp.Domain.Helpers;
using Idp.Domain.Repositories;
using Idp.Domain.Services.Aws;

namespace Idp.Api.Seeder;

public class JsonWebKeySeeder(IServiceScopeFactory scopeFactory) : IHostedService
{
    private const string BaseAlias = "genesis";
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = scopeFactory.CreateScope();
        
        var signingKeyRepository = scope.ServiceProvider.GetRequiredService<ISigningKeyRepository>();
        var kmsService = scope.ServiceProvider.GetRequiredService<IKmsService>();
        
        var issueKey = await signingKeyRepository.FindLatestIssueKey();
        
        if(issueKey is not null)
            return;

        var key = await kmsService.CreateKeyAsync(BaseAlias);
        
        var publicKey = await kmsService.GetPublicKey(key);

        await signingKeyRepository.Add(new SigningKeyEntity
        {
            Algorithm = TokenEnvironment.Ecc,
            CanIssue = true,
            KeyId = key,
            PublicJwk = publicKey
        }, DefaultUserOperation.Seeder, cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}