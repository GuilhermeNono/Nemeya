using Hangfire;
using Idp.Api.Jobs.Abstractions.Interfaces;
using Idp.Api.Jobs.Recurring;

namespace Idp.Api.Extensions;

public static class JobExtension
{
    private static void RegisterJobs(IServiceCollection services)
    {
        services.AddJob<ExampleJob>();
    }

    public static void RegisterHangfireJobs(this IServiceCollection services)
    {
        RegisterJobs(services);

        var serviceProvider = services.BuildServiceProvider();

        var recurringJob = serviceProvider.GetRequiredService<IRecurringJobManagerV2>();

        var recurringJobServices = serviceProvider.GetServices(typeof(IRecurringJob)).Cast<IRecurringJob>();

        var cancellationToken = new CancellationTokenSource();

        foreach (var jobService in recurringJobServices)
        {
            recurringJob.AddOrUpdate(jobService.GetType().Name,
                () => jobService.ExecuteAsync(cancellationToken.Token),
                jobService.CronExpression);
        }
    }

    private static void AddJob<TJob>(this IServiceCollection service) where TJob : class, IRecurringJob, IJob
    {
        service.AddScoped<IRecurringJob, TJob>();
    }
}