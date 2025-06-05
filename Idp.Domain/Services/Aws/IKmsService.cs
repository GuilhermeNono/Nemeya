namespace Idp.Domain.Services.Aws;

public interface IKmsService
{
    Task<byte[]> EncryptAsync(string keyId, string plainText);
    Task<string> DecryptAsync(byte[] encryptedData);
    Task<string> CreateKeyAsync(string aliasName);
    Task<bool> VerifySignAsync(string keyId, byte[] data, byte[] signature);
    Task<byte[]> SignAsync(string keyId, byte[] data);
}