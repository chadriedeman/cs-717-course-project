using System.Data;

namespace WeightTrackerApi.DataAccess
{
    public interface IDatabaseConnectionProvider
    {
        IDbConnection Connection { get; }
    }
}
