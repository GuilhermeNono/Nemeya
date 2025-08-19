using Idp.CrossCutting.Configurations;

namespace Idp.Api.Configurations;

public class CryptographyConfiguration : ICryptographyConfiguration
{
    public string Key { get; set; } = string.Empty;
    public string Iv { get; set; } = string.Empty;
}