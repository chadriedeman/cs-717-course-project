using System.Collections.Generic;
using System.Threading.Tasks;
using WeightTrackerApi.DataAccess.Repositories;
using WeightTrackerApi.Domain.Models;

namespace WeightTrackerApi.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task AddUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteUserAsync(string username)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetUserAsync(string username)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsersAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
