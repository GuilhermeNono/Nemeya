using Idp.Infrastructure.DbUp;
using Testcontainers.MsSql;
using Xunit;

namespace Idp.Test.Integration.Infrastructure.Migrations;

public class MigrationTest : IAsyncLifetime
{

    private readonly MsSqlContainer _dbContainer = new MsSqlBuilder()
        .WithImage("mcr.microsoft.com/mssql/server:2025-latest")
        .WithPassword("-K8fub/71cD<(P$p")
        .WithPortBinding(1435)
        .WithCleanUp(true)
        .Build();

    public async Task InitializeAsync() => await _dbContainer.StartAsync();

    public async Task DisposeAsync() => await _dbContainer.StopAsync();

    [Fact]
    public void Running_Migration_Service()
    {
        var functionsMigration = DbUpExtension.RunMigration(_dbContainer.GetConnectionString(), DbUpExtension.FunctionMigrationsPath);
        var mainMigration = DbUpExtension.RunMigration(_dbContainer.GetConnectionString(), DbUpExtension.MainMigrationsPath);
        
        Assert.All([functionsMigration, mainMigration], migration => Assert.Equal(MigrationStatusEnum.Successful, migration));
    }
}