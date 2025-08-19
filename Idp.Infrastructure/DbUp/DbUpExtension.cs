using System.Text;
using System.Text.RegularExpressions;
using DbUp;
using DbUp.Engine;
using DbUp.ScriptProviders;
using DbUp.Support;
using Idp.CrossCutting.Exceptions.Http.Internal;
using Idp.Domain.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace Idp.Infrastructure.DbUp;

public static class DbUpExtension
{
    private const string ServerConnectionName = "MainDatabase";
    public const string MainMigrationsPath = "Versions";
    public const string FunctionMigrationsPath = "Functions";
    
    private static readonly IReadOnlyList<string> ServerConnections = [ServerConnectionName];

    private static IApplicationBuilder RunFunctionsDbUp(this IApplicationBuilder application,
        IConfiguration configuration)
    {
        Console.WriteLine("| Checando funções customizadas dos Bancos |");

        foreach (var connectionName in ServerConnections)
            RunMigration(configuration.GetConnectionString(connectionName), FunctionMigrationsPath);

        Console.WriteLine("| Checagem das funções finalizadas |\n");

        return application;
    }


    private static IApplicationBuilder RunMainDbUp(this IApplicationBuilder application, IConfiguration configuration)
    {
        Console.WriteLine("| Checando arquivos de migração do Banco |");

        RunMigration(configuration.GetConnectionString(ServerConnectionName), MainMigrationsPath);
        
        Console.WriteLine("| Checagem de migração do Banco Finalizada |\n");
        
        return application;
    }
    
    private static UpgradeEngine ConfigureEngine(string connectionString, params string[] folder) => DeployChanges.To
        .SqlDatabase(connectionString)
        .WithScriptsFromFileSystem(Path.Combine([AppDomain.CurrentDomain.BaseDirectory, "DbUp", "Scripts", .. folder]),
            new FileSystemScriptOptions
            {
                IncludeSubDirectories = true,
                Extensions = ["*.sql"],
                Encoding = Encoding.UTF8
            })
        .WithFilter(new ExecutionOrderScriptFilter())
        .WithTransactionPerScript()
        .Build();
    
    public static MigrationStatusEnum RunMigration(string? connectionString, params string[] folder)
    {
        if(string.IsNullOrEmpty(connectionString))
            throw new MigrationConnectionException(connectionString);
        
        EnsureDatabase.For.SqlDatabase(connectionString);

        var upgrader = ConfigureEngine(connectionString, folder);

        var result = upgrader.PerformUpgrade();
        
        if (!result.Successful)
            throw new DatabaseMigrationFailed();
        
        return result.Successful ? MigrationStatusEnum.Successful : MigrationStatusEnum.Failed;
    }

    public static void AddMigrationService(this IApplicationBuilder application, IConfiguration configuration) =>
        application.RunFunctionsDbUp(configuration)
            .RunMainDbUp(configuration);
}

public class ExecutionOrderScriptFilter : IScriptFilter
{
    private const string ScriptFileName = "script";
    private const string TempScriptFileName = "Temp";

    public IEnumerable<SqlScript> Filter(
        IEnumerable<SqlScript> sorted,
        HashSet<string> executedScriptNames,
        ScriptNameComparer comparer)
    {
        var sortedScripts = sorted
            .Where(s => s.SqlScriptOptions.ScriptType == ScriptType.RunAlways ||
                        !executedScriptNames.Contains(s.Name, comparer)).Where(x =>
                !EnvironmentHelper.IsProductionEnvironment || x.Name.Contains(ScriptFileName) ||
                (!x.Name.Contains(ScriptFileName) && !x.Name.Contains(TempScriptFileName)))
            .OrderBy(str => IsTemporary(str.Name))
            .ThenBy(str => ExtractVersion(str.Name));

        return sortedScripts;
    }

    private static Version ExtractVersion(string scriptName)
    {
        var match = Regex.Match(scriptName, @"\d+(\.\d+)+");
        return match.Success ? Version.Parse(match.Value) : new Version(0, 0, 0);
    }

    private static bool IsTemporary(string scriptName) =>
        scriptName.Contains(TempScriptFileName, StringComparison.OrdinalIgnoreCase);
}

public enum MigrationStatusEnum
{
    Failed,
    Successful
}