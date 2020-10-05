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
            var query = $@""; // TODO

            var queryParameters = new DynamicParameters();

            _databaseConnection.ExecuteScalar(query, queryParameters);
        }

        public void AddUserWeighIn(string username, WeighIn weighIn)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
