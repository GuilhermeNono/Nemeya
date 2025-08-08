using Idp.CrossCutting.Exceptions.Http.Internal.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.Internal;

public class MigrationConnectionException : InternalException
{
    public MigrationConnectionException(string? connectionString) : base(ErrorMessage.Exception.MigrationConnection(connectionString))
    {
    }
}