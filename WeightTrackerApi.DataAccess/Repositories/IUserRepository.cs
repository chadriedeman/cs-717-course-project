using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeightTrackerApi.Domain.Models;

namespace WeightTrackerApi.DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<User> GetUserAsync(string username);
        Task<IEnumerable<User>> GetUsersAsync();
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(string username);
        Task AddUserWeighInAsync(string username, WeighIn weighIn);
        Task<WeighIn> GetUserWeighInAsync(string username, DateTime date);
        Task DeleteUserWeighInAsync(string username, DateTime date);
        Task UpdateUserWeighInAsync(string username, WeighIn weighIn);
        Task<IEnumerable<WeighIn>> GetUserWeighInsAsync(string username, DateTime beginDate, DateTime endDate);
    }
}
