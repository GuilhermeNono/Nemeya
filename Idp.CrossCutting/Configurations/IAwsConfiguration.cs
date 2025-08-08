namespace Idp.CrossCutting.Configurations;

public interface IAwsConfiguration
{
    public string ServiceUrl { get; set; }
    public bool UseHttp { get; set; }
    public string AuthenticationRegion { get; set; }
    public string AccessKey { get; set; }
    public string SecretKey { get; set; }
}