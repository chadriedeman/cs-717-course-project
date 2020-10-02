using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeightTrackerApi.Domain.Models;

namespace WeightTrackerApi.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task AddUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public async Task AddUserWeighInAsync(string username, WeighIn weighIn)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteUserAsync(string username)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteUserWeighInAsync(string username, DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserAsync(string username)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetUsersAsync(string username)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<WeighIn> GetUserWeighInAsync(string username, DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task GetUserWeighInsAsync(string username, DateTime beginDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateUserWeighInAsync(string username, WeighIn weighIn)
        {
            throw new NotImplementedException();
        }
    }
}
