using Idp.CrossCutting.Configurations;

namespace Idp.Api.Configurations;

public class AwsConfiguration : IAwsConfiguration
{
    public string ServiceUrl { get; set; } = string.Empty;
    public bool UseHttp { get; set; }
    public string AuthenticationRegion { get; set; } = string.Empty;
    public string AccessKey { get; set; } = string.Empty;
    public string SecretKey { get; set; } = string.Empty;
}