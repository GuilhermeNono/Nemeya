namespace Idp.CrossCutting.Configurations;

public interface IAppConfiguration
{
    public string ClientName { get; set; }
    public string ClientSecret { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Document { get; set; }
}