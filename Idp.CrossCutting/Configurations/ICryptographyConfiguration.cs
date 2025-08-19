namespace Idp.CrossCutting.Configurations;

public interface ICryptographyConfiguration
{
    public string Key { get; set; }
    public string Iv { get; set; }
}