using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using WeightTrackerApi.Domain.Models;

namespace WeightTrackerApi.Tests.BusinessTests.ServiceTests.UserServiceTests
{
    public class DeleteUserWeighInTests : UserServiceTestsBase
    {
        [Test]
        public void ShouldThrowArgumentExceptionWhenUsernameIsEmpty()
        {
            var emptyUsername = string.Empty;

            var date = _chance.Date();

            Action deleteUserWeighInCall = () => _subjectUnderTest.DeleteUserWeighIn(emptyUsername, date);

            deleteUserWeighInCall.Should().Throw<ArgumentException>()
                .WithMessage("No username was provided to DeleteUserWeighIn.");
        }

        [Test]
        public void ShouldThrowArgumentExceptionWhenUserDoesNotExist()
        {
            var username = _chance.Sentence();

            var date = _chance.Date();

            User userInDatabase = null;

            _userRepository.GetUser(Arg.Any<string>()).Returns(userInDatabase);

            Action deleteUserWeighInCall = () => _subjectUnderTest.DeleteUserWeighIn(username, date);

            deleteUserWeighInCall.Should().Throw<ArgumentException>()
                .WithMessage($"{username} does not exist in the database.");
        }

        [Test]
        public void ShouldThrowArgumentExceptionWhenWeighInDoesNotExistOnDateForUser()
        {
            var username = _chance.Sentence();

            var date = _chance.Date();

            var userInDatabase = GetValidUser();

            _userRepository.GetUser(Arg.Any<string>()).Returns(userInDatabase);

            WeighIn weighInInDatabase = null;

            _userRepository.GetUserWeighIn(Arg.Any<string>(), Arg.Any<DateTime>()).Returns(weighInInDatabase);

            Action deleteUserWeighInCall = () => _subjectUnderTest.DeleteUserWeighIn(username, date);

            deleteUserWeighInCall.Should().Throw<ArgumentException>()
                .WithMessage($"No weigh-in exists for {username} on {date.ToShortDateString()}.");
        }

        [Test]
        public void ShouldDeleteUserWeighInWhenValidUsernameAndValidDate()
        {
            var username = _chance.Sentence();

            var date = _chance.Date();

            var userInDatabase = GetValidUser();

            _userRepository.GetUser(Arg.Any<string>()).Returns(userInDatabase);

            var weighInInDatabase = GetValidWeighIn();

            _userRepository.GetUserWeighIn(Arg.Any<string>(), Arg.Any<DateTime>()).Returns(weighInInDatabase);

            _subjectUnderTest.DeleteUserWeighIn(username, date);

            _userRepository.Received(1).DeleteUserWeighIn(Arg.Any<string>(), Arg.Any<DateTime>());
        }
    }
}
