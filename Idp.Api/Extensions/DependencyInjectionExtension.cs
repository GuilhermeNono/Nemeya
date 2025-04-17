using Idp.Application.Error.Catcher;
using Idp.Domain.Errors.Abstractions.Interfaces;

namespace Idp.Api.Extensions;

public static class DependencyInjectionExtension
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IErrorCatcher, ErrorCatcher>();
    }
}