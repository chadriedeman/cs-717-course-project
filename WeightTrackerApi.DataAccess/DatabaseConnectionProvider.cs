using System.Collections.Generic;
using System.Data;
using Dapper;

namespace WeightTrackerApi.DataAccess
{
    public class DatabaseConnectionProvider : IDatabaseConnectionProvider
    {
        private readonly IDbConnection _connection;

        public DatabaseConnectionProvider(IDbConnection databaseConnection)
        {
            _connection = databaseConnection;

            _connection.Open();
        }

        public IEnumerable<T> Query<T>(string sql, object queryParameters)
        {
            return _connection.Query<T>(sql, queryParameters);
        }

        public T QuerySingle<T>(string sql, object queryParameters)
        {
            return _connection.QuerySingle<T>(sql, queryParameters);
        }

        public object ExecuteScalar(string sql, object queryParameters)
        {
            return _connection.ExecuteScalar(sql, queryParameters);
        }

        public IEnumerable<T> Query<T>(string sql)
        {
            return _connection.Query<T>(sql);
        }
    }
}
