using Idp.CrossCutting.Configurations;
using Idp.Domain.Entities;
using Idp.Domain.Enums.Smart;
using Idp.Domain.Helpers;
using Idp.Domain.Repositories;

namespace Idp.Api.Seeder;

public class AdminClientSeeder(IServiceScopeFactory scopeFactory) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = scopeFactory.CreateScope();
        var clientRepository = scope.ServiceProvider.GetRequiredService<IClientRepository>();
        var clientScopeRepository = scope.ServiceProvider.GetRequiredService<IClientScopeRepository>();
        var scopeRepository = scope.ServiceProvider.GetRequiredService<IScopeRepository>();
        var clientRedirectRepository = scope.ServiceProvider.GetRequiredService<IClientRedirectRepository>();
        var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
        var personRepository = scope.ServiceProvider.GetRequiredService<IPersonRepository>();
        var appConfiguration = scope.ServiceProvider.GetRequiredService<IAppConfiguration>();
        var cryptoConfiguration = scope.ServiceProvider.GetRequiredService<ICryptographyConfiguration>();

        var hasClients = await clientRepository.HasAtLeastOneClient();
        
        if(hasClients)
            return;

        var client = await clientRepository.Add(new ClientEntity
        {
            Name = appConfiguration.ClientName,
            Secret = CryptoHelper.Encrypt(appConfiguration.ClientSecret, cryptoConfiguration.Key,
                cryptoConfiguration.Iv),
            ClientId = Ulid.NewUlid().ToString()
        }, DefaultUserOperation.Seeder, cancellationToken);

        var scopes = await scopeRepository.Find();

        foreach (var entityScope in scopes)
        {
            await clientScopeRepository.Add(new ClientScopeEntity
            {
                ClientId = client.Id,
                ScopeId = entityScope.Id
            }, DefaultUserOperation.Seeder, cancellationToken);
        }

        await clientRedirectRepository.Add(new ClientRedirectEntity()
        {
            ClientId = client.Id,
            Uri = "https://localhost:4200/callback",
        }, DefaultUserOperation.Seeder, cancellationToken);

        var user = await userRepository.Add(new UserEntity
        {
            Email = appConfiguration.UserEmail,
            Username = appConfiguration.UserName,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(appConfiguration.Password)
        }, DefaultUserOperation.Seeder, cancellationToken);

        var document = ValidHelper.DocumentValidate(appConfiguration.Document);

        await personRepository.Add(new PersonEntity
        {
            Id = user.Id,
            FirstName = appConfiguration.FirstName,
            LastName = appConfiguration.LastName,
            BirthDate = DateOnly.FromDateTime(DateTime.Now),
            Document = appConfiguration.Document,
            PhoneNumber = null,
            NormalizedDocument = document.Normalized
        }, DefaultUserOperation.Seeder, cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}