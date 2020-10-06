using Dapper;
using System;
using System.Collections.Generic;
using WeightTrackerApi.Domain.Models;

namespace WeightTrackerApi.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDatabaseConnectionProvider _databaseConnectionProvider;

        public UserRepository(IDatabaseConnectionProvider databaseConnectionProvider)
        {
            _databaseConnectionProvider = databaseConnectionProvider;
        }

        public void AddUser(User user)
        {
            var query = $@"INSERT INTO User
                                (USERNAME,
                                FIRST_NAME,
                                LAST_NAME)
                           VALUES
                                (@{nameof(user.Username)},
                                 @{nameof(user.FirstName)},
                                 @{nameof(user.LastName)});";

            var queryParameters = new DynamicParameters();

            queryParameters.Add($"@{nameof(user.Username)}", user.Username);
            queryParameters.Add($"@{nameof(user.FirstName)}", user.FirstName);
            queryParameters.Add($"@{nameof(user.LastName)}", user.LastName);

            _databaseConnectionProvider.Connection.ExecuteScalar(query, queryParameters);
        }

        public void AddUserWeighIn(string username, WeighIn weighIn)
        {
            var query = $@"INSERT INTO WeighIn
                                (USER_ID,
                                 DATE,
                                 WEIGHT,
                                 UNIT_OF_MEASUREMENT)
                           VALUES
                                (@{nameof(weighIn.UserId)},
                                 @{nameof(weighIn.Date)},
                                 @{nameof(weighIn.Weight)},
                                 @{nameof(weighIn.UnitOfMeasurement)});";

            var queryParameters = new DynamicParameters();

            queryParameters.Add($"@{nameof(weighIn.UserId)}", weighIn.UserId);
            queryParameters.Add($"@{nameof(weighIn.Date)}", weighIn.Date);
            queryParameters.Add($"@{nameof(weighIn.Weight)}", weighIn.Weight);
            queryParameters.Add($"@{nameof(weighIn.UnitOfMeasurement)}", weighIn.UnitOfMeasurement);

            _databaseConnectionProvider.Connection.ExecuteScalar(query, queryParameters);
        }

        public void DeleteUser(string username)
        {
            var query = $@"DELETE
                           FROM User
                           WHERE USERNAME = @{nameof(username)};";

            var queryParameters = new DynamicParameters();

            queryParameters.Add($"@{nameof(username)}", username);

            _databaseConnectionProvider.Connection.ExecuteScalar(query, queryParameters);
        }

        public void DeleteUserWeighIn(string username, DateTime date)
        {
            var query = $@"DELETE
                           FROM WeighIn W
                           JOIN User U
                           WHERE U.USERNAME = @{nameof(username)}
                                 AND W.DATE = @{nameof(date)};";

            var queryParameters = new DynamicParameters();

            queryParameters.Add($"@{nameof(username)}", username);
            queryParameters.Add($"@{nameof(date)}", date);

            _databaseConnectionProvider.Connection.ExecuteScalar(query, queryParameters);
        }

        public User GetUser(string username)
        {
            var query = $@"SELECT U.ID {nameof(User.Id)},
                                  U.USERNAME {nameof(User.Username)},
                                  U.FIRST_NAME {nameof(User.FirstName)},
                                  U.LAST_NAME {nameof(User.LastName)},
                                  W.ID {nameof(WeighIn.Id)},
                                  W.USER_ID {nameof(WeighIn.UserId)},
                                  W.DATE {nameof(WeighIn.Date)},
                                  W.WEIGHT {nameof(WeighIn.Weight)},
                                  W.UNIT_OF_MEASUREMENT {nameof(WeighIn.UnitOfMeasurement)}
                           FROM User U
                           JOIN WeighIn W 
                                ON U.ID = W.USER_ID
                           WHERE U.USERNAME = @{nameof(username)};";

            var queryParameters = new DynamicParameters();

            queryParameters.Add($"@{nameof(username)}", username);

            return _databaseConnectionProvider.Connection.QuerySingle<User>(query, queryParameters);
        }

        public IEnumerable<User> GetUsers()
        {
            var query = $@"SELECT U.ID,
                                  U.USERNAME,
                                  U.FIRST_NAME,
                                  U.LAST_NAME,
                                  W.ID,
                                  W.DATE,
                                  W.WEIGHT,
                                  W.UNIT_OF_MEASUREMENT
                           FROM User U
                           JOIN WeighIn W 
                                ON U.ID = W.USER_ID;";

            return _databaseConnectionProvider.Connection.Query<User>(query);
        }

        public WeighIn GetUserWeighIn(string username, DateTime date)
        {
            var query = $@"SELECT W.USER_ID {nameof(WeighIn.UserId)},
                                  W.DATE {nameof(WeighIn.Date)},
                                  W.WEIGHT {nameof(WeighIn.Weight)},
                                  W.UNIT_OF_MEASUREMENT {nameof(WeighIn.UnitOfMeasurement)}
                           FROM WeighIn W
                           JOIN User U 
                                ON W.USER_ID = U.ID
                           WHERE U.USERNAME = @{nameof(username)}
                                 AND W.DATE = @{nameof(date)};";

            var queryParameters = new DynamicParameters();

            queryParameters.Add($"@{nameof(date)}", date);
            queryParameters.Add($"@{nameof(username)}", username);

            return _databaseConnectionProvider.Connection.QuerySingle<WeighIn>(query, queryParameters);
        }

        public IEnumerable<WeighIn> GetUserWeighIns(string username, DateTime beginDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            var query = $@"UPDATE User
                           SET USERNAME = {nameof(user.Username)},
                               FIRST_NAME = {nameof(user.FirstName)},
                               LAST_NAME = {nameof(user.LastName)}
                           WHERE ID = @{nameof(user.Id)}";

            var queryParameters = new DynamicParameters();

            queryParameters.Add($"@{nameof(user.Id)}", user.Id);

            _databaseConnectionProvider.Connection.ExecuteScalar(query, queryParameters);
        }

        public void UpdateUserWeighIn(string username, WeighIn weighIn)
        {
            throw new NotImplementedException();
        }
    }
}
