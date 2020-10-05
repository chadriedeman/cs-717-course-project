using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using WeightTrackerApi.Domain.Models;

namespace WeightTrackerApi.Tests.BusinessTests.ServiceTests.UserServiceTests
{
    public class GetUserWeighInTests : UserServiceTestsBase
    {
        [Test]
        public void ShouldThrowArgumentExceptionWhenUsernameIsEmpty()
        {
            var emptyUsername = string.Empty;

            var date = _chance.Date();

            Action getUserWeighInCall = () => _subjectUnderTest.GetUserWeighIn(emptyUsername, date);

            getUserWeighInCall.Should().Throw<ArgumentException>()
                .WithMessage("No username was provided to GetUserWeighIn.");
        }

        [Test]
        public void ShouldThrowArgumentExceptionWhenUserDoesNotExist()
        {
            var username = _chance.Sentence();

            var date = _chance.Date();

            User userInDatabase = null;

            _userRepository.GetUser(Arg.Any<string>()).Returns(userInDatabase);

            Action getUserWeighInCall = () => _subjectUnderTest.GetUserWeighIn(username, date);

            getUserWeighInCall.Should().Throw<ArgumentException>()
                .WithMessage($"{username} does not exist in the database.");
        }

        [Test]
        public void ShouldGetUserWeighInWhenUsernameIsValid()
        {
            var username = _chance.Sentence();

            var date = _chance.Date();

            var userInDatabase = GetValidUser();

            _userRepository.GetUser(Arg.Any<string>()).Returns(userInDatabase);

            _subjectUnderTest.GetUserWeighIn(username, date);

            _userRepository.Received(1).GetUserWeighIn(Arg.Any<string>(), Arg.Any<DateTime>());
        }
    }
}
