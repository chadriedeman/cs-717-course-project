using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using WeightTrackerApi.Domain.Models;

namespace WeightTrackerApi.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _databaseConnection;

        public UserRepository(IDbConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public void AddUser(User user)
        {
            var query = $@"INSERT INTO User
                           ()
                           VALUES
                           ();"; // TODO

            var queryParameters = new DynamicParameters();

            _databaseConnection.ExecuteScalar(query, queryParameters);
        }

        public void AddUserWeighIn(string username, WeighIn weighIn)
        {

            var query = $@"INSERT INTO WeighIn
                           ()
                           VALUES
                           ();"; // TODO

            var queryParameters = new DynamicParameters();

            _databaseConnection.ExecuteScalar(query, queryParameters);
        }

        public void DeleteUser(string username)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserWeighIn(string username, DateTime date)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string username)
        {
            var query = $@"SELECT U.ID,
                                  U.USERNAME,
                                  U.FIRST_NAME,
                                  U.LAST_NAME
                           FROM User U
                           JOIN WeighIn W 
                                ON U.ID = W.USER_ID
                           WHERE U.USERNAME = @username;"; 

            var queryParameters = new DynamicParameters(); // TODO

            return _databaseConnection.QuerySingle<User>(query, queryParameters);
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public WeighIn GetUserWeighIn(string username, DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WeighIn> GetUserWeighIns(string username, DateTime beginDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserWeighIn(string username, WeighIn weighIn)
        {
            throw new NotImplementedException();
        }
    }
}
