using System.Collections.Generic;
using WeightTrackerApi.Domain.Models;

namespace WeightTrackerApi.Business.Services
{
    public interface IUserService
    {
        void AddUser(User user);
        User GetUser(string username);
        List<User> GetUsers();
        void UpdateUser(User user);
        void DeleteUser(string username);
    }
}
