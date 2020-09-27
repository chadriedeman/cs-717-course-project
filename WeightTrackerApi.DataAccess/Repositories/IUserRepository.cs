using System.Collections.Generic;
using System.Threading.Tasks;
using WeightTrackerApi.Domain.Models;

namespace WeightTrackerApi.DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task DeleteUserAsync(string username);
        Task<User> GetUserAsync(string username);
        Task<IEnumerable<User>> GetUsersAsync(string username);
        Task UpdateUserAsync(User user);
    }
}
