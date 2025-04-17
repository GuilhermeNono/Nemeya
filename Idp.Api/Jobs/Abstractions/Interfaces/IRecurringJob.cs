namespace Idp.Api.Jobs.Abstractions.Interfaces;

public interface IRecurringJob : IJob
{
    public string CronExpression { get; }
}