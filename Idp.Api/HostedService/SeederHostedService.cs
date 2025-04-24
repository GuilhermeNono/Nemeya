using OpenIddict.Abstractions;

namespace Idp.Api.HostedService;

public class SeederHostedService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public SeederHostedService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var manager = scope.ServiceProvider.GetRequiredService<IOpenIddictApplicationManager>();

        const string clientId = "myclient2";

        if (await manager.FindByClientIdAsync(clientId, cancellationToken) is null)
        {
            await manager.CreateAsync(new OpenIddictApplicationDescriptor
            {
                ClientId = clientId,
                ClientSecret = "supersecret", 
                DisplayName = "My Client App",
                Permissions =
                {
                    OpenIddictConstants.Permissions.Endpoints.Token,
                    OpenIddictConstants.Permissions.GrantTypes.ClientCredentials,
                    OpenIddictConstants.Permissions.Prefixes.Scope + "api"
                }
            }, cancellationToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}