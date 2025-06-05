using Idp.Domain.Enums.Smart.Base;
using Microsoft.Extensions.Hosting;

namespace Idp.Domain.Enums.Smart;

public sealed class Environment(string value, int index) : SmartEnum<Environment>(value, index)
{
    public static readonly Environment EnvironmentVariable = new("ASPNETCORE_ENVIRONMENT", 1);
    public static readonly Environment Production = new("Production", 2);
    public static readonly Environment Staging = new("Staging", 3);
    public static readonly Environment Development = new("Development", 4);
    public static readonly Environment Docker = new("Docker", 5);

    public static bool MustRenderSwaggerUi(IHostEnvironment hostEnvironment) =>
        hostEnvironment.IsEnvironment(Development) || hostEnvironment.IsEnvironment(Docker);
}