using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using WeightTrackerApi.Domain.Models;

namespace WeightTrackerApi.Tests.BusinessTests.ServiceTests.UserServiceTests
{
    public class AddUserWeighIn : UserServiceTestsBase
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

        [Test]
        public void ShouldThrowArgumentExceptionWhenWeighInAlreadyExistsForUserOnThatDate()
        {
            var username = _chance.Sentence();

            var weighIn = GetValidWeighIn();

            var user = GetValidUser();

            var existingWeighIn = GetValidWeighIn();

            _userRepository.GetUser(Arg.Any<string>()).Returns(user);

            _userRepository.GetUserWeighIn(Arg.Any<string>(), Arg.Any<DateTime>()).Returns(existingWeighIn);

            Action addUserCall = () => _subjectUnderTest.AddUserWeighIn(username, weighIn);

            addUserCall.Should().Throw<ArgumentException>()
                .WithMessage($"A weigh-in already exists for ${username} on ${weighIn.Date.ToShortDateString()}.");
        }

        [Test]
        public void ShouldAddUserWeighInWhenInputIsValid()
        {
            var username = _chance.Sentence();

            var weighIn = GetValidWeighIn();

            var user = GetValidUser();

            WeighIn existingWeighIn = null;

            _userRepository.GetUser(Arg.Any<string>()).Returns(user);

            _userRepository.GetUserWeighIn(Arg.Any<string>(), Arg.Any<DateTime>()).Returns(existingWeighIn);

            _subjectUnderTest.AddUserWeighIn(username, weighIn);

            _userRepository.Received(1).AddUserWeighIn(Arg.Any<string>(), Arg.Any<WeighIn>());
        }
    }
}
