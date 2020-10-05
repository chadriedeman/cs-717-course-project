using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using WeightTrackerApi.Domain.Models;

namespace WeightTrackerApi.Tests.BusinessTests.ServiceTests.UserServiceTests
{
    public class UpdateUserTests : UserServiceTestsBase
    {
        [Test]
        public void ShouldThrowArgumentExceptionWhenUserIsNull()
        {
            User nullUser = null;

            Action updateUserCall = () => _subjectUnderTest.UpdateUser(nullUser);

            updateUserCall.Should().Throw<ArgumentException>()
                .WithMessage("No username was provided to UpdateUser.");
        }

        [Test]
        public void ShouldThrowArgumentExceptionWhenUsernameIsEmpty()
        {
            var userWithInvalidUsername = new User
            {
                Username = string.Empty
            };

            Action updateUserCall = () => _subjectUnderTest.UpdateUser(userWithInvalidUsername);

            updateUserCall.Should().Throw<ArgumentException>()
                .WithMessage("No username was provided to UpdateUser.");
        }

        [Test]
        public void ShouldThrowArgumentExceptionWhenUserDoesNotExist()
        {
            var user = GetValidUser();

            User userInDatabase = null;

            _userRepository.GetUser(Arg.Any<string>()).Returns(userInDatabase);

            Action updateUserCall = () => _subjectUnderTest.UpdateUser(user);

            updateUserCall.Should().Throw<ArgumentException>()
                .WithMessage($"{user.Username} does not exist in the database.");
        }

        [Test]
        public void ShouldUpdateUserWhenGivenValidUser()
        {
            var user = GetValidUser();

            var userInDatabase = GetValidUser();

            _userRepository.GetUser(Arg.Any<string>()).Returns(userInDatabase);

            _subjectUnderTest.UpdateUser(user);

            _userRepository.Received(1).UpdateUser(Arg.Any<User>());
        }
    }
}
