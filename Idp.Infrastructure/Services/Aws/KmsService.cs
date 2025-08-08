using System.Text;
using Amazon;
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;
using Amazon.Runtime;
using Idp.Domain.Services.Aws;

namespace Idp.Infrastructure.Services.Aws;

public class KmsService : IKmsService
{
    private readonly AmazonKeyManagementServiceClient _client;

    public KmsService()
    {
        var config = new AmazonKeyManagementServiceConfig
        {
            ServiceURL = "https://localhost.localstack.cloud:4566",
            UseHttp = false,
            AuthenticationRegion = "us-east-1",
           
        };
            
        _client = new AmazonKeyManagementServiceClient(new BasicAWSCredentials("test", "test"), config);
    }

    public async Task<string> CreateKeyAsync(string aliasName)
    {
        var key = await _client.CreateKeyAsync(new CreateKeyRequest
        {
            Description = "Chave para assinatura dos JWT's",
            KeyUsage = KeyUsageType.SIGN_VERIFY,
            KeySpec = KeySpec.ECC_NIST_P256,
            Origin = OriginType.AWS_KMS
        });
        
        var keyId = key.KeyMetadata.KeyId;

        await _client.CreateAliasAsync(new CreateAliasRequest
        {
            AliasName = $"alias/{aliasName}",
            TargetKeyId = keyId
        });

        return keyId;
    }

    public async Task<byte[]> EncryptAsync(string? keyId, string plainText)
    {
        var request = new EncryptRequest
        {
            Plaintext = new MemoryStream(Encoding.UTF8.GetBytes(plainText)),
            KeyId = keyId
        };
        
        var response = await _client.EncryptAsync(request);
        return response.CiphertextBlob.ToArray();
    }

    public async Task<string> DecryptAsync(byte[] encryptedData)
    {
        var request = new DecryptRequest
        {
            CiphertextBlob = new MemoryStream(encryptedData)
        };
        
        var response = await _client.DecryptAsync(request);
        return Encoding.UTF8.GetString(response.Plaintext.ToArray());
    }    
    
    public async Task<bool> VerifySignAsync(string keyId, byte[] data, byte[] signature)
    {
        var response = await _client.VerifyAsync(new VerifyRequest
        {
            KeyId = keyId,
            Message = new MemoryStream(data),
            Signature = new MemoryStream(signature),
            MessageType = MessageType.RAW,
            SigningAlgorithm = SigningAlgorithmSpec.ECDSA_SHA_256
        });

        return response.SignatureValid ?? false;
    }
    
    public async Task<byte[]> SignAsync(string keyId, byte[] data)
    {
        var response = await _client.SignAsync(new SignRequest
        {
            KeyId = keyId,
            Message = new MemoryStream(data),
            MessageType = MessageType.RAW,
            SigningAlgorithm = SigningAlgorithmSpec.ECDSA_SHA_256
        });

        return response.Signature.ToArray();
    }

    public async Task<string> GetPublicKey(string key)
    {
        var response = await _client.GetPublicKeyAsync(new GetPublicKeyRequest
        {
            KeyId = key
        });
        
        var keyInBytes =  response.PublicKey.ToArray();
        
        return Encoding.UTF8.GetString(keyInBytes);
    }
}