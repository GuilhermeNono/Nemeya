using Hangfire;
using Idp.Api.Jobs.Abstractions.Interfaces;
using MediatR;

namespace Idp.Api.Jobs.Recurring;

public class ExampleJob : IRecurringJob
{
    private readonly ISender _sender;
    
    public string CronExpression => Cron.Minutely();

    public ExampleJob(ISender sender)
    {
        _sender = sender;
    }
    
    public Task ExecuteAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    } 
}