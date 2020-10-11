using System.Collections.Generic;

namespace WeightTrackerApi.DataAccess
{
    public interface IDatabaseConnectionProvider
    {
        IEnumerable<T> Query<T>(string sql);
        IEnumerable<T> Query<T>(string sql, object queryParameters);
        T QuerySingle<T>(string sql, object queryParameters);
        object ExecuteScalar(string sql, object queryParameters);
    }
}
