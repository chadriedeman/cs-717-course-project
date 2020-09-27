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

        public async Task DeleteUserAsync(string username)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> GetUserAsync(string username)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetUsersAsync(string username)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
