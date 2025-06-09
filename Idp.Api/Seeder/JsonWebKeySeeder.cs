using Idp.Domain.Entities;
using Idp.Domain.Repositories;
using Idp.Domain.Services.Aws;

namespace Idp.Api.Seeder;

public class JsonWebKeySeeder : IHostedService
{
    private readonly ISigningKeyRepository _signingKeyRepository;
    private readonly IKmsService _kmsService;

    public JsonWebKeySeeder(IKmsService kmsService, ISigningKeyRepository signingKeyRepository)
    {
        _kmsService = kmsService;
        _signingKeyRepository = signingKeyRepository;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var issueKey = await _signingKeyRepository.FindLatestIssueKey();
        
        if(issueKey is not null)
            return;
        

    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}