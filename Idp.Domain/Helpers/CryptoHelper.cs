using System.Security.Cryptography;
using System.Text;

namespace Idp.Domain.Helpers;

public static class CryptoHelper
{
    private static Aes Create(string key, string iv)
    {
        var aes = Aes.Create();
        aes.Key = Convert.FromBase64String(key);
        aes.IV = Convert.FromBase64String(iv);
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        return aes;
    }
    
    public static string Encrypt(string value, string key, string iv)
    {
        using var aes = Create(key, iv);
        using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

        var bytes = Encoding.UTF8.GetBytes(value);
        var encrypted = encryptor.TransformFinalBlock(bytes, 0, bytes.Length);
        return Convert.ToBase64String(encrypted);
    }

    public static string Decrypt(string value, string key, string iv)
    {
        using var aes = Create(key, iv);
        using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        var bytes = Convert.FromBase64String(value ?? string.Empty);
        var decrypted = decryptor.TransformFinalBlock(bytes, 0, bytes.Length);
        return Encoding.UTF8.GetString(decrypted);
    }

    public static string GenerateAuthorizationCode() => Guid.NewGuid().ToString("N")[..16];
}