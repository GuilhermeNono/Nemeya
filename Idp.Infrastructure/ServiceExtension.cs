using System.Security.Cryptography;
using System.Text;
using Idp.CrossCutting.Configurations;
using Idp.Domain.Database.Context;
using Idp.Domain.Database.Transaction;
using Idp.Domain.Helpers;
using Idp.Domain.Services.Aws;
using Idp.Infrastructure.EFCore.Database.Context;
using Idp.Infrastructure.EFCore.Database.Services;
using Idp.Infrastructure.Services.Aws;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Idp.Infrastructure;

public static class ServiceExtension
{
    private const string MainConnectionName = "MainDatabase";
    private const string AuditConnectionName = "AuditDatabase";

    #region || Database ||

    public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IMainContext, MainContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString(MainConnectionName));
        });

        services.AddDbContext<IAuditContext, AuditContext>(opt =>
            {
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                opt.UseSqlServer(configuration.GetConnectionString(AuditConnectionName));
            }
        );

        services.AddScoped<ITransactionService, TransactionService>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IKmsService, KmsService>();

        return services;
    }

    public static IServiceCollection AddMainRepositories(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddAuditRepositories(this IServiceCollection services)
    {
        return services;
    }

    #endregion

    #region || Auth ||

    public static IServiceCollection ConfigureAuthentication(this IServiceCollection services)
    {
        var jwtConfiguration = services.BuildServiceProvider().GetRequiredService<IJwtConfiguration>();

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Authority = "https://localhost:7178";
                options.Audience = jwtConfiguration.Audience;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfiguration.Issuer,
                    ValidAudience = jwtConfiguration.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.SecretKey)),
                    ClockSkew = TimeSpan.Zero
                };
            });

        return services;
    }

    public static void ConfigureAuthorization
        (this IServiceCollection services)
    {
        services.AddAuthorizationBuilder()
            .AddPolicy(RoleHelper.Administrator, policy => { policy.RequireRole(RoleHelper.Administrator); })
            .AddPolicy(RoleHelper.User, policy => { policy.RequireRole(RoleHelper.User); });
    }

    #endregion
}