using MediatR;

namespace Idp.Application.Members.Abstractions.Queries;

public interface IQuery<out T> : IRequest<T>
{
}

public interface IQuery : IRequest
{
}
