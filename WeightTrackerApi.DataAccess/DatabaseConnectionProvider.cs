using System.Data;
using System.Data.SqlClient;

namespace WeightTrackerApi.DataAccess
{
    public class DatabaseConnectionProvider : IDatabaseConnectionProvider
    {
        private IDbConnection _connection;

        public IDbConnection Connection {
            get
            {
                if (_connection == null)
                    _connection = FetchNewConnection();

                return _connection;
            } 
        }

        public DatabaseConnectionProvider()
        {
            _connection = FetchNewConnection();
        }

        private IDbConnection FetchNewConnection()
        {
            var databaseConnectionString = new SqlConnectionStringBuilder
            {
                DataSource = "" // TODO: Setup connection string in config
            }
            .ConnectionString;

            var databaseConnection = new SqlConnection(databaseConnectionString);

            databaseConnection.Open();

            return databaseConnection;
        }
    }
}
