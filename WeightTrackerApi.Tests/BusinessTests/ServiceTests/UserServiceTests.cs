using ChanceNET;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using WeightTrackerApi.Business.Services;
using WeightTrackerApi.DataAccess.Repositories;
using WeightTrackerApi.Domain.Enumerations;
using WeightTrackerApi.Domain.Models;

namespace WeightTrackerApi.Tests.BusinessTests.ServiceTests
{
    public class UserServiceTests
    {
        private readonly Chance _chance;
        private readonly IUserRepository _userRepository;
        private readonly UserService _subjectUnderTest;

        protected UserServiceTests()
        {
            _chance = new Chance();
            _userRepository = Substitute.For<IUserRepository>();
            _subjectUnderTest = new UserService(_userRepository);
        }

        protected User GetValidUser()
        {
            return new User
            {
                Id = _chance.Natural(),
                Username = _chance.Sentence(),
                FirstName = _chance.Sentence(),
                LastName = _chance.Sentence(),
                WeighIns = new List<WeighIn>()
            };
        }

        protected WeighIn GetValidWeighIn()
        {
            return new WeighIn
            {
                Id = _chance.Natural(),
                UserId = _chance.Natural(),
                Weight = _chance.Double(),
                Date = _chance.Date(),
                UnitOfMeasurement = UnitOfMeasurement.Pounds
            };
        }

        public class AddUser : UserServiceTests
        {
            [Test]
            public void ShouldThrowArgumentExceptionWhenUserIsNull()
            {
                User nullUser = null;

                Action addUserCall = () => _subjectUnderTest.AddUser(nullUser);

                addUserCall.Should().Throw<ArgumentException>()
                    .WithMessage("No user was provided to AddUser.");
            }

            [Test]
            public void ShouldThrowArgumentExceptionWhenUserHasEmptyUsername()
            {
                var userWithInvalidUsername = new User
                {
                    Username = string.Empty
                };

                Action addUserCall = () => _subjectUnderTest.AddUser(userWithInvalidUsername);

                addUserCall.Should().Throw<ArgumentException>()
                    .WithMessage("No user was provided to AddUser.");
            }

            [Test]
            public void ShouldThrowArgumentExceptionWhenUserAlreadyExistsInTheDatabase()
            {
                var user = GetValidUser();

                _userRepository.GetUser(Arg.Any<string>()).Returns(user);

                Action addUserCall = () => _subjectUnderTest.AddUser(user);

                addUserCall.Should().Throw<ArgumentException>()
                    .WithMessage($"{user.Username} already exists.");
            }

            [Test]
            public void ShouldAddUserWhenUserIsValid()
            {
                var validUser = GetValidUser();

                _subjectUnderTest.AddUser(validUser);

                _userRepository.Received(1).AddUser(Arg.Any<User>());
            }
        }

        public class AddUserWeighIn : UserServiceTests
        {
            [Test]
            public void ShouldThrowArgumentExceptionWhenUsernameIsEmpty()
            {
                var emptyUserName = string.Empty;

                var weighIn = GetValidWeighIn();

                Action addUserCall = () => _subjectUnderTest.AddUserWeighIn(emptyUserName, weighIn);

                addUserCall.Should().Throw<ArgumentException>()
                    .WithMessage("No user was provided to AddUserWeighIn.");
            }

            [Test]
            public void ShouldThrowArgumentExceptionWhenWeighInIsNull()
            {
                var username = _chance.Sentence();

                WeighIn nullWeighIn = null;

                Action addUserCall = () => _subjectUnderTest.AddUserWeighIn(username, nullWeighIn);

                addUserCall.Should().Throw<ArgumentException>()
                    .WithMessage("No weigh-in was provided to AddUserWeighIn.");
            }

            [Test]
            public void ShouldThrowArgumentExceptionWhenUserDoesNotExistInDatabase()
            {
                var username = _chance.Sentence();

                var weighIn = GetValidWeighIn();

                User userInDatabase = null;

                _userRepository.GetUser(Arg.Any<string>()).Returns(userInDatabase);

                Action addUserCall = () => _subjectUnderTest.AddUserWeighIn(username, weighIn);

                addUserCall.Should().Throw<ArgumentException>()
                    .WithMessage($"{username} does not exist.");
            }
        }
    }
}
