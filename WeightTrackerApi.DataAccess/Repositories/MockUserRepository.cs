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
            var user = await GetUserAsync(username);

            user.WeighIns.Add(weighIn);
        }

        public async Task DeleteUserAsync(string username)
        {
            var user = await GetUserAsync(username);

            await new Task(() => _users.Remove(user));
        }

        public async Task DeleteUserWeighInAsync(string username, DateTime date)
        {
            var user = await GetUserAsync(username);

            var weighIn = await GetUserWeighInAsync(username, date);

            user.WeighIns.Remove(weighIn);
        }

        public async Task<User> GetUserAsync(string username)
        {
            return await new Task<User>(() => _users.FirstOrDefault(user => user.Username == username));
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await new Task<IEnumerable<User>>(() => _users);
        }

        public async Task<WeighIn> GetUserWeighInAsync(string username, DateTime date)
        {
            var user = await GetUserAsync(username);

            return user.WeighIns.FirstOrDefault(weighIn => DatesAreEqual(weighIn.Date, date));
        }

        public async Task<IEnumerable<WeighIn>> GetUserWeighInsAsync(string username, DateTime beginDate, DateTime endDate)
        {
            var user = await GetUserAsync(username);

            return user.WeighIns.Where(weighIn => DateTime.Compare(weighIn.Date, beginDate) >=0 && DateTime.Compare(weighIn.Date, endDate) <= 0).ToList();
        }

        public async Task UpdateUserAsync(User user)
        {
            await new Task(async () =>
            {
                var userInList = await GetUserAsync(user.Username);

                userInList = user;
            });
        }

        public async Task UpdateUserWeighInAsync(string username, WeighIn updatedWeighIn)
        {
            var currentWeighIn = await GetUserWeighInAsync(username, updatedWeighIn.Date);

            currentWeighIn = updatedWeighIn;
        }

        private bool DatesAreEqual(DateTime date1, DateTime date2)
        {
            return date1.Year == date2.Year &&
                   date1.Month == date2.Month &&
                   date1.Day == date2.Day;
        }
    }
}
