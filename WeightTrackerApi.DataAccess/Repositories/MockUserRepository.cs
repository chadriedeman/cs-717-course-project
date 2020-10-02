using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeightTrackerApi.Domain.Models;

namespace WeightTrackerApi.DataAccess.Repositories
{
    public class MockUserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public async Task AddUserAsync(User user)
        {
            await new Task(() => _users.Add(user));
        }

        public async Task AddUserWeighInAsync(string username, WeighIn weighIn)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteUserAsync(string username)
        {
            var user = await GetUserAsync(username);

            await new Task(() => _users.Remove(user));
        }

        public async Task DeleteUserWeighInAsync(string username, DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserAsync(string username)
        {
            return await new Task<User>(() => _users.FirstOrDefault(user => user.Username == username));
        }

        public async Task<IEnumerable<User>> GetUsersAsync(string username)
        {
            return await new Task<IEnumerable<User>>(() => _users);
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
            await new Task(async () =>
            {
                var userInList = await GetUserAsync(user.Username);

                userInList = user;
            });
        }

        public async Task UpdateUserWeighInAsync(string username, WeighIn weighIn)
        {
            throw new NotImplementedException();
        }
    }
}
