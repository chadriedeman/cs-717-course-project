using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WeightTrackerApi.Domain.Models;

namespace WeightTrackerApi.Tests.BusinessTests.ServiceTests.UserServiceTests
{
    public class UpdateUserWeighInTests : UserServiceTestsBase
    {
        [Test]
        public void ShouldThrowArgumentExceptionWhenUsernameIsEmpty()
        {
            var emptyUsername = string.Empty;

            var weighIn = GetValidWeighIn();

            Action updateUserWeighInCall = () => _subjectUnderTest.UpdateUserWeighIn(emptyUsername, weighIn);

            updateUserWeighInCall.Should().Throw<ArgumentException>()
                .WithMessage("No username was provided to UpdateUserWeighIn.");
        }

        [Test]
        public void ShouldThrowArgumentExceptionWhenWeighInIsNull()
        {
            var username = _chance.Sentence();

            WeighIn weighIn = null;

            Action updateUserWeighInCall = () => _subjectUnderTest.UpdateUserWeighIn(username, weighIn);

            updateUserWeighInCall.Should().Throw<ArgumentException>()
                .WithMessage("No weigh-in was provided to UpdateUserWeighIn.");
        }

        [Test]
        public void ShouldThrowArgumentExceptionWhenUserDoesNotExist()
        {
            var username = _chance.Sentence();

            var weighIn = GetValidWeighIn();

            User userInDatabase = null;

            _userRepository.GetUser(Arg.Any<string>()).Returns(userInDatabase);

            Action updateUserWeighInCall = () => _subjectUnderTest.UpdateUserWeighIn(username, weighIn);

            updateUserWeighInCall.Should().Throw<ArgumentException>()
                .WithMessage($"{username} does not exist in the database.");
        }

        [Test]
        public void ShouldThrowArgumentExceptionWhenWeighInDoesNotExist()
        {
            var username = _chance.Sentence();

            var weighIn = GetValidWeighIn();

            var userInDatabase = GetValidUser();

            _userRepository.GetUser(Arg.Any<string>()).Returns(userInDatabase);

            WeighIn weighInInDatabase = null;

            _userRepository.GetUserWeighIn(Arg.Any<string>(), Arg.Any<DateTime>()).Returns(weighInInDatabase);

            Action updateUserWeighInCall = () => _subjectUnderTest.UpdateUserWeighIn(username, weighIn);

            updateUserWeighInCall.Should().Throw<ArgumentException>()
                .WithMessage($"No weigh-in exists for ${username} on ${weighIn.Date.ToShortDateString()}.");
        }

        [Test]
        public void ShouldUpdateUserWeighInWhenValidUsernameAndWeighIn()
        {
            var username = _chance.Sentence();

            var weighIn = GetValidWeighIn();

            var userInDatabase = GetValidUser();

            _userRepository.GetUser(Arg.Any<string>()).Returns(userInDatabase);

            var weighInInDatabase = GetValidWeighIn();

            _userRepository.GetUserWeighIn(Arg.Any<string>(), Arg.Any<DateTime>()).Returns(weighInInDatabase);

            _subjectUnderTest.UpdateUserWeighIn(username, weighIn);

            _userRepository.Received(1).UpdateUserWeighIn(Arg.Any<string>(), Arg.Any<WeighIn>());
        }
    }
}
