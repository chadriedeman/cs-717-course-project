using System;
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
                    _connection = FetchConnection();

                return _connection;
            } 
        }

        public DatabaseConnectionProvider()
        {
            _connection = FetchConnection();
        }

        private IDbConnection FetchConnection()
        {
            var databaseConnectionString = new SqlConnectionStringBuilder
            {
                // TODO
            }
            .ConnectionString;

            var databaseConnection = new SqlConnection(databaseConnectionString);

            databaseConnection.Open();

            return databaseConnection;
        }
    }
}
