﻿using System;
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

        public async Task AddUserAsync(User user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Username))
                throw new ArgumentException("No user was provided to AddUserAsync.");

            var userExistsInDatabase = await UserExistsInDatabaseAsync(user.Username);

            if (userExistsInDatabase)
                throw new ArgumentException($"{user.Username} already exists.");

            await _userRepository.AddUserAsync(user);
        }

        public async Task DeleteUserAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("No username was provided to DeleteUserAsync.");

            var userExistsInDatabase = await UserExistsInDatabaseAsync(username);

            if (!userExistsInDatabase)
                throw new ArgumentException($"{username} does not exist in the database.");

            await _userRepository.DeleteUserAsync(username);
        }

        public async Task<User> GetUserAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("No username was provided to GetUserAsync.");

            return await _userRepository.GetUserAsync(username);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await GetUsersAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Username))
                throw new ArgumentException("No username was provided to UpdateUserAsync.");

            var userExistsInDatabase = await UserExistsInDatabaseAsync(user.Username);

            if (!userExistsInDatabase)
                throw new ArgumentException($"{user.Username} does not exist in the database.");

            await _userRepository.UpdateUserAsync(user);
        }

        private async Task<bool> UserExistsInDatabaseAsync(string username)
        {
            var user = await GetUserAsync(username);

            return user != null;
        }
    }
}
