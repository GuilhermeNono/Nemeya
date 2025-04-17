using System.Diagnostics.CodeAnalysis;
using Idp.Domain.Enums;
using Idp.Domain.Helpers;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Idp.Domain.Annotations;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class ApiRouteAttribute : Attribute, IRouteTemplateProvider
{
    [StringSyntax("Route")]
    public string? Template { get; }

    private int? _order;
    public int Order
    {
        get => _order ?? 0;
        set => _order = value;
    }

    /// <inheritdoc />
    int? IRouteTemplateProvider.Order => _order;

    /// <inheritdoc />
    public string? Name { get; set; }

    public ApiRouteAttribute([StringSyntax("Route")] string? route, ApiRouteVersion version = ApiRouteVersion.None)
    {
        Template = version is ApiRouteVersion.None ? $"{route}" : $"{EnumHelper.GetDescription(version)}/{route}";
    }
}