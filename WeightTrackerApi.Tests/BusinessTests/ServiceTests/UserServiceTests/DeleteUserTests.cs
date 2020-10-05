using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WeightTrackerApi.Domain.Models;

namespace WeightTrackerApi.Tests.BusinessTests.ServiceTests.UserServiceTests
{
    public class DeleteUserTests : UserServiceTestsBase
    {
        [Test]
        public void ShouldThrowArgumentExceptionWhenUsernameIsEmpty()
        {
            var emptyUsername = string.Empty;

            Action deleteUserCall = () => _subjectUnderTest.DeleteUser(emptyUsername);

            deleteUserCall.Should().Throw<ArgumentException>()
                .WithMessage("No username was provided to DeleteUser.");
        }

        [Test]
        public void ShouldThrowArgumentExceptionWhenUserDoesNotExist()
        {
            var username = _chance.Sentence();

            User userInDatabase = null;

            _userRepository.GetUser(Arg.Any<string>()).Returns(userInDatabase);

            Action deleteUserCall = () => _subjectUnderTest.DeleteUser(username);

            deleteUserCall.Should().Throw<ArgumentException>()
                .WithMessage($"{username} does not exist in the database.");
        }

        [Test]
        public void ShouldDeleteUserWhenUsernameIsValid()
        {
            var username = _chance.Sentence();

            User userInDatabase = GetValidUser();

            _userRepository.GetUser(Arg.Any<string>()).Returns(userInDatabase);

            _subjectUnderTest.DeleteUser(username);

            _userRepository.Received(1).DeleteUser(Arg.Any<string>());
        }
    }
}
