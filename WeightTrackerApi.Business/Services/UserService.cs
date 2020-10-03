using System;
using System.Collections.Generic;
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

        public void AddUser(User user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Username))
                throw new ArgumentException("No user was provided to AddUser.");

            var userExistsInDatabase = UserExistsInDatabase(user.Username);

            if (userExistsInDatabase)
                throw new ArgumentException($"{user.Username} already exists.");

            _userRepository.AddUser(user);
        }

        public void AddUserWeighIn(string username, WeighIn weighIn)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("No user was provided to AddUserWeighIn.");

            if (weighIn == null)
                throw new ArgumentException("No weigh-in was provided to AddUserWeighIn.");

            var userExistsInDatabase = UserExistsInDatabase(username);

            if (!userExistsInDatabase)
                throw new ArgumentException($"{username} does not exist.");

            var weighInAlreadyExists = WeighInAlreadyExists(username, weighIn.Date);

            if (weighInAlreadyExists)
            {
                throw new ArgumentException($"A weigh-in already exists for ${username} on ${weighIn.Date.ToShortDateString()}.");
            }

            _userRepository.AddUserWeighIn(username, weighIn);
        }

        public void DeleteUser(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("No username was provided to DeleteUser.");

            var userExistsInDatabase = UserExistsInDatabase(username);

            if (!userExistsInDatabase)
                throw new ArgumentException($"{username} does not exist in the database.");

            _userRepository.DeleteUser(username);
        }

        public void DeleteUserWeighIn(string username, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("No username was provided to DeleteUserWeighIn.");

            var userExistsInDatabase = UserExistsInDatabase(username);

            if (!userExistsInDatabase)
                throw new ArgumentException($"{username} does not exist in the database.");

            _userRepository.DeleteUserWeighIn(username, date);
        }

        public User GetUser(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("No username was provided to GetUser.");

            return _userRepository.GetUser(username);
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public WeighIn GetUserWeighIn(string username, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("No username was provided to GetUserWeighIn.");

            var userExistsInDatabase = UserExistsInDatabase(username);

            if (!userExistsInDatabase)
                throw new ArgumentException($"{username} does not exist in the database.");

            return _userRepository.GetUserWeighIn(username, date);
        }

        public IEnumerable<WeighIn> GetUserWeighIns(string username, DateTime beginDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("No username was provided to GetUserWeighIns.");

            var userExistsInDatabase = UserExistsInDatabase(username);

            if (!userExistsInDatabase)
                throw new ArgumentException($"{username} does not exist in the database.");

            return _userRepository.GetUserWeighIns(username, beginDate, endDate);
        }

        public void UpdateUser(User user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Username))
                throw new ArgumentException("No username was provided to UpdateUser.");

            var userExistsInDatabase = UserExistsInDatabase(user.Username);

            if (!userExistsInDatabase)
                throw new ArgumentException($"{user.Username} does not exist in the database.");

            _userRepository.UpdateUser(user);
        }

        public void UpdateUserWeighIn(string username, WeighIn weighIn)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("No username was provided to UpdateUserWeighIn.");

            var userExistsInDatabase = UserExistsInDatabase(username);

            if (!userExistsInDatabase)
                throw new ArgumentException($"{username} does not exist in the database.");

            var weighInAlreadyExists = WeighInAlreadyExists(username, weighIn.Date);

            if (!weighInAlreadyExists)
            {
                throw new ArgumentException($"No weigh-in exists for ${username} on ${weighIn.Date.ToShortDateString()}.");
            }

            _userRepository.UpdateUserWeighIn(username, weighIn);
        }

        private bool UserExistsInDatabase(string username)
        {
            var user = GetUser(username);

            return user != null;
        }

        private bool WeighInAlreadyExists(string username, DateTime date)
        {
            var weighIn = GetUserWeighIn(username, date);

            return weighIn != null;
        }
    }
}
