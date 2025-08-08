using Idp.Domain.Enums.Smart.Base;

namespace Idp.Domain.Enums.Smart;

public sealed class DefaultUserOperation(string value, int index) : SmartEnum<DefaultUserOperation>(value, index)
{
    public static readonly DefaultUserOperation System = new ("System#0", 1);
    public static readonly DefaultUserOperation Seeder = new ("Seeder#0", 2);
    public static readonly DefaultUserOperation Anonymous = new ("Anonymous#-1", 3);
}