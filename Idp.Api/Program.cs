using System.Text.Json;
using System.Text.Json.Serialization;
using Hangfire;
using Idp.Api.Extensions;
using Idp.Api.Middlewares;
using Idp.Application;
using Idp.Application.Members.Behaviours;
using Idp.Infrastructure;
using Idp.Infrastructure.DbUp;
using Idp.Presentation.Controllers.Abstractions;
using MediatR;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(opt =>
    {
        opt.Filters.Add<ExceptionHandler>();
    })
    .AddApplicationPart(typeof(ApiController).Assembly)
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterConfiguration(builder.Configuration);

#region | Authentication |

builder.Services.ConfigureAuthentication()
    .ConfigureAuthorization();

#endregion

#region | Database |

builder.Services.ConfigureDatabase(builder.Configuration)
    .AddMainRepositories()
    .AddAuditRepositories();

#endregion

#region | MediatR | 

builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(AssemblyReference.Assembly));
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionPipelineBehaviour<,>));

#endregion

#region | Serilog |

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});

#endregion

#region | HangFire |

builder.Services.AddHangfire(config => config
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(builder.Configuration.GetConnectionString("HangFire")));

if(builder.Environment.IsDevelopment())
    builder.Services.AddHangfireServer();

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region | DbUp |

app.AddDbUp(app.Configuration);

#endregion

app.UseHttpsRedirection();
app.UseSerilogRequestLogging();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();