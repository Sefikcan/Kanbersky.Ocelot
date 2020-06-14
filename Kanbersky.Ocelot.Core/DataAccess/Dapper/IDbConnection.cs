using System.Data.Common;

namespace Kanbersky.Ocelot.Core.DataAccess.Dapper
{
    public interface IDbConnection
    {
        DbConnection CreateDbConnection();
    }
}
