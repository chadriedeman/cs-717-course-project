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

        /// Pre-condition: None.
        /// 
        /// Post-condition: The user will be added to the database.
        public void AddUser(User user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Username))
                throw new ArgumentException("No user was provided to AddUser.");

            var userExistsInDatabase = UserExistsInDatabase(user.Username);

            if (userExistsInDatabase)
                throw new ArgumentException($"{user.Username} already exists.");

            _userRepository.AddUser(user);
        }

        /// Pre-condition: The user must exist in the database.
        /// 
        /// Post-condition: The weigh-in will be added to the database.
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
                throw new ArgumentException($"A weigh-in already exists for ${username} on ${weighIn.Date.ToShortDateString()}.");

            var user = GetUser(username);

            weighIn.UserId = user.Id;

            _userRepository.AddUserWeighIn(username, weighIn);
        }

        /// Pre-condition: The given user must exist in the database.
        /// 
        /// Post-condition: The user will be deleted from the database.
        public void DeleteUser(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("No username was provided to DeleteUser.");

            var userExistsInDatabase = UserExistsInDatabase(username);

            if (!userExistsInDatabase)
                throw new ArgumentException($"{username} does not exist in the database.");

            _userRepository.DeleteUser(username);
        }

        /// Pre-condition: The user and weigh-in must exist in the database.
        /// 
        /// Post-condition: The weigh-in will be deleted from the database.
        public void DeleteUserWeighIn(string username, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("No username was provided to DeleteUserWeighIn.");

            var userExistsInDatabase = UserExistsInDatabase(username);

            if (!userExistsInDatabase)
                throw new ArgumentException($"{username} does not exist in the database.");

            var weighInToBeDeleted = GetUserWeighIn(username, date);

            if (weighInToBeDeleted == null)
                throw new ArgumentException($"No weigh-in exists for {username} on {date.ToShortDateString()}.");

            _userRepository.DeleteUserWeighIn(username, date);
        }

        /// Pre-condition: None.
        /// 
        /// Post-condition: The user will be returned from the database if the user exist, otherwise the function will return null.
        public User GetUser(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("No username was provided to GetUser.");

            return _userRepository.GetUser(username);
        }

        /// Pre-condition: None.
        /// 
        /// Post-condition: All users will be returned from the database.
        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        /// Pre-condition: The user and weigh-in must exist.
        /// 
        /// Post-condition: The weigh-in will be returned from the database.
        public WeighIn GetUserWeighIn(string username, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("No username was provided to GetUserWeighIn.");

            var userExistsInDatabase = UserExistsInDatabase(username);

            if (!userExistsInDatabase)
                throw new ArgumentException($"{username} does not exist in the database.");

            return _userRepository.GetUserWeighIn(username, date);
        }

        /// Pre-condition: The user must exist.
        /// 
        /// Post-condition: All weigh-ins between the given dates will be returned from the database.
        public IEnumerable<WeighIn> GetUserWeighIns(string username, DateTime beginDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("No username was provided to GetUserWeighIns.");

            if (beginDate.CompareTo(endDate) > 0)
                throw new ArgumentException("Begin date cannot be greater than end date.");

            var userExistsInDatabase = UserExistsInDatabase(username);

            if (!userExistsInDatabase)
                throw new ArgumentException($"{username} does not exist in the database.");

            return _userRepository.GetUserWeighIns(username, beginDate, endDate);
        }

        /// Pre-condition: The user must exist.
        /// 
        /// Post-condition: The user will be updated in the database.
        public void UpdateUser(User user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Username))
                throw new ArgumentException("No username was provided to UpdateUser.");

            var userExistsInDatabase = UserExistsInDatabase(user.Username);

            if (!userExistsInDatabase)
                throw new ArgumentException($"{user.Username} does not exist in the database.");

            _userRepository.UpdateUser(user);
        }

        /// Pre-condition: The user and weigh-in must exist.
        /// 
        /// Post-condition: The weigh-in will be updated in the database.
        public void UpdateUserWeighIn(string username, WeighIn weighIn)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("No username was provided to UpdateUserWeighIn.");

            if (weighIn == null)
                throw new ArgumentException("No weigh-in was provided to UpdateUserWeighIn.");

            var userExistsInDatabase = UserExistsInDatabase(username);

            if (!userExistsInDatabase)
                throw new ArgumentException($"{username} does not exist in the database.");

            var weighInAlreadyExists = WeighInAlreadyExists(username, weighIn.Date);

            if (!weighInAlreadyExists)
                throw new ArgumentException($"No weigh-in exists for ${username} on ${weighIn.Date.ToShortDateString()}.");

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
