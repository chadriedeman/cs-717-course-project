using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task DeleteUserAsync(string username)
        {
            var user = await GetUserAsync(username);

            await new Task(() => _users.Remove(user));
        }

        public async Task<User> GetUserAsync(string username)
        {

        }

        public async Task<IEnumerable<User>> GetUsersAsync(string username)
        {
            return await new Task<IEnumerable<User>>(() => _users);
        }

        public async Task UpdateUserAsync(User user)
        {
            var userInList = await GetUserAsync(user.Username);

            userInList = user;
        }
    }
}
