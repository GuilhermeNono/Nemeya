using System.ComponentModel;

namespace Idp.Domain.Enums;

public enum InternalOperation
{
    [Description("Create")]
    C,
    [Description("Update")]
    U,
    [Description("Delete")]
    D
}
