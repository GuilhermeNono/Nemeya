using Idp.CrossCutting.Configurations;

namespace Idp.Api.Configurations;

public class AppConfiguration : IAppConfiguration
{
    public string Root { get; set; } = string.Empty;
    public string ClientName { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
}