using System.Collections.Generic;
using System.Threading.Tasks;
using WeightTrackerApi.Domain.Models;

namespace WeightTrackerApi.Business.Services
{
    public interface IUserService
    {
        Task AddUserAsync(User user);
        Task<User> GetUserAsync(string username);
        Task<IEnumerable<User>> GetUsersAsync();
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(string username);
    }
}
