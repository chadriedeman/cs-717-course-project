using System.Data;
using System.Data.SqlClient;

namespace WeightTrackerApi.DataAccess
{
    public class DatabaseConnectionProvider : IDatabaseConnectionProvider
    {
        private readonly string _connectionString;
        private IDbConnection _connection;

        public IDbConnection Connection {
            get
            {
                if (_connection == null)
                    _connection = FetchNewConnection(_connectionString);

                return _connection;
            } 
        }

        public DatabaseConnectionProvider(string connectionString)
        {
            _connectionString = connectionString;
            _connection = FetchNewConnection(connectionString);
        }

        private IDbConnection FetchNewConnection(string connectionString)
        {
            var databaseConnectionString = new SqlConnectionStringBuilder
            {
                DataSource = connectionString
            }
            .ConnectionString;

            var databaseConnection = new SqlConnection(databaseConnectionString);

            databaseConnection.Open();

            return databaseConnection;
        }
    }
}
