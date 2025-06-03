using System.Reflection;
using Idp.Domain.Annotations;
using Idp.Domain.Database.Transaction;
using Idp.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Idp.Application.Members.Behaviours;

public class TransactionPipelineBehaviour<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : ITransactional
{
    private readonly ILogger<TransactionPipelineBehaviour<TRequest, TResponse>> _logger;
    private readonly ITransactionService _transactionService;

    public TransactionPipelineBehaviour(ILogger<TransactionPipelineBehaviour<TRequest, TResponse>> logger,
        ITransactionService transactionService)
    {
        _logger = logger;
        _transactionService = transactionService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        TResponse? response = default;

        var annotation = request.GetType().GetCustomAttribute<TransactionTypeAttribute>();
        var transactionType = annotation?.TransactionType ?? DbTransactionType.ReadUncommitted;

        if (transactionType == DbTransactionType.NoTransaction ||
            _transactionService.IsTransactionActive && annotation?.TransactionType == null)
            return await next(cancellationToken);

        try
        {
            await _transactionService.ExecuteInTransactionContextAsync(async () => { response = await next(cancellationToken); },
                transactionType, TransactionLogLevel.None, cancellationToken, true);
        }
        catch (Exception e)
        {
            _logger.LogError("|> Ocorreu um problema durante o processo de transação:\n {Message} \n {StackTracer}",
                e.Message, e.StackTrace);
            throw;
        }

        return response!;
    }
}