using Idp.Domain.Enums.Smart.Base;

namespace Idp.Domain.Enums.Smart;

public sealed class TokenEnvironment(string value, int index) : SmartEnum<TokenEnvironment>(value, index)
{
    public static readonly TokenEnvironment Ecc =  new("ECC", 1); 
    public static readonly TokenEnvironment Rsa =  new("RSA", 2); 
}