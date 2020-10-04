using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using WeightTrackerApi.Domain.Models;

namespace WeightTrackerApi.Tests.BusinessTests.ServiceTests.UserServiceTests
{
    public class AddUser : UserServiceTestsBase
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
}
