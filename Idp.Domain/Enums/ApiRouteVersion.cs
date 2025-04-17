using System.ComponentModel;

namespace Idp.Domain.Enums;

public enum ApiRouteVersion
{
    None,
    [Description("v1")]
    Version1,
    [Description("v2")]
    Version2,
    [Description("v3")]
    Version3
}