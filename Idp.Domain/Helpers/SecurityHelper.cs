using System.Security.Cryptography;
using System.Text;
using Idp.Domain.Objects.Security;

namespace Idp.Domain.Helpers;

public static class SecurityHelper
{
    public static SecurityGroupKey CreateRsaKeys()
    {
        using var rsa = RSA.Create();

        var publicKey = rsa.ExportRSAPublicKey();
        var privateKey = rsa.ExportRSAPrivateKey();

        return new SecurityGroupKey(Convert.ToBase64String(publicKey), Convert.ToBase64String(privateKey));
    }
}