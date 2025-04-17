namespace Idp.Api.Jobs.Abstractions.Interfaces;

public interface IJob
{
    public Task ExecuteAsync(CancellationToken cancellationToken);
}