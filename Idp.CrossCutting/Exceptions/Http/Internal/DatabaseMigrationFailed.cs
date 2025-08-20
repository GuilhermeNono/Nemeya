using Idp.CrossCutting.Exceptions.Http.Internal.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.Internal;

public class DatabaseMigrationFailed : InternalException
{
    public DatabaseMigrationFailed(string error) : base(ErrorMessage.Exception.MigrationFailed(error))
    {
    }
}
