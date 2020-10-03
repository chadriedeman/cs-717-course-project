using System;
using System.Collections.Generic;
using System.Linq;
using WeightTrackerApi.Domain.Models;

namespace WeightTrackerApi.DataAccess.Repositories
{
    public class MockUserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public void AddUser(User user)
        {
             _users.Add(user);
        }

        public void AddUserWeighIn(string username, WeighIn weighIn)
        {
            var user = GetUser(username);

            user.WeighIns.Add(weighIn);
        }

        public void DeleteUser(string username)
        {
            var user = GetUser(username);

            _users.Remove(user);
        }

        public void DeleteUserWeighIn(string username, DateTime date)
        {
            var user = GetUser(username);

            var weighIn = GetUserWeighIn(username, date);

            user.WeighIns.Remove(weighIn);
        }

        public User GetUser(string username)
        {
            return _users.FirstOrDefault(user => user.Username == username);
        }

        public IEnumerable<User> GetUsers()
        {
            return _users;
        }

        public WeighIn GetUserWeighIn(string username, DateTime date)
        {
            var user = GetUser(username);

            return user.WeighIns.FirstOrDefault(weighIn => DatesAreEqual(weighIn.Date, date));
        }

        public IEnumerable<WeighIn> GetUserWeighIns(string username, DateTime beginDate, DateTime endDate)
        {
            var user = GetUser(username);

            return user.WeighIns.Where(weighIn => DateTime.Compare(weighIn.Date, beginDate) >= 0 && DateTime.Compare(weighIn.Date, endDate) <= 0).ToList();
        }

        public void UpdateUser(User user)
        {
            var userInList = GetUser(user.Username);

            userInList = user;
        }

        public void UpdateUserWeighIn(string username, WeighIn updatedWeighIn)
        {
            var currentWeighIn = GetUserWeighIn(username, updatedWeighIn.Date);

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
