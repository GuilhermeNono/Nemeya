using Idp.Domain.Enums.Smart.Base;
using Microsoft.Extensions.Hosting;

namespace Idp.Domain.Enums.Smart;

public sealed class EnvironmentsVariable(string value, int index) : SmartEnum<EnvironmentsVariable>(value, index)
{
    public static readonly EnvironmentsVariable EnvironmentsVariableVariable = new("ASPNETCORE_ENVIRONMENT", 1);
    public static readonly EnvironmentsVariable Production = new("Production", 2);
    public static readonly EnvironmentsVariable Staging = new("Staging", 3);
    public static readonly EnvironmentsVariable Development = new("Development", 4);
    public static readonly EnvironmentsVariable Docker = new("Docker", 5);

    public static bool MustRenderSwaggerUi(IHostEnvironment hostEnvironment) =>
        hostEnvironment.IsEnvironment(Development) || hostEnvironment.IsEnvironment(Docker);
}