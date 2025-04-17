using Idp.Domain.Database.Transaction;
using MediatR;

namespace Idp.Application.Members.Abstractions.Commands;

public interface ICommand<out T> : IRequest<T>, ITransactional
{
}

public interface ICommand : IRequest, ITransactional
{
}
