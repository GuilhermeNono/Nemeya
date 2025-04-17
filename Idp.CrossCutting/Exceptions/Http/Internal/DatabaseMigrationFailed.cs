using Idp.CrossCutting.Exceptions.Http.Internal.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.Internal;

public class DatabaseMigrationFailed : InternalException
{
    public DatabaseMigrationFailed() : base(ErrorMessage.Exception.MigrationFailed())
    {
    }
}
