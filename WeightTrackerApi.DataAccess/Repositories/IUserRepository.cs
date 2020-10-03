using System;
using System.Collections.Generic;
using WeightTrackerApi.Domain.Models;

namespace WeightTrackerApi.DataAccess.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUser(string username);
        IEnumerable<User> GetUsers();
        void UpdateUser(User user);
        void DeleteUser(string username);
        void AddUserWeighIn(string username, WeighIn weighIn);
        WeighIn GetUserWeighIn(string username, DateTime date);
        void DeleteUserWeighIn(string username, DateTime date);
        void UpdateUserWeighIn(string username, WeighIn weighIn);
        IEnumerable<WeighIn> GetUserWeighIns(string username, DateTime beginDate, DateTime endDate);
    }
}
