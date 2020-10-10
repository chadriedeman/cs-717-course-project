using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using WeightTrackerApi.Domain.Models;

namespace WeightTrackerApi.Tests.BusinessTests.ServiceTests.UserServiceTests
{
    public class GetUserWeighInsTests : UserServiceTestsBase
    {
        [Test]
        public void ShouldThrowArgumentExceptionWhenUsernameIsEmpty()
        {
            var emptyUsername = string.Empty;

            var beginDate = _chance.Date();

            var endDate = _chance.Date();

            Action getUserWeighInCall = () => _subjectUnderTest.GetUserWeighIns(emptyUsername, beginDate, endDate);

            getUserWeighInCall.Should().Throw<ArgumentException>()
                .WithMessage("No username was provided to GetUserWeighIns.");
        }

        [Test]
        public void ShouldThrowArgumentExceptionWhenBeginDateGreaterThanEndDate()
        {
            var username = _chance.Word();

            var beginDate = DateTime.MaxValue;

            var endDate = DateTime.MinValue;

            Action getUserWeighInCall = () => _subjectUnderTest.GetUserWeighIns(username, beginDate, endDate);

            getUserWeighInCall.Should().Throw<ArgumentException>()
                .WithMessage("Begin date cannot be greater than end date.");
        }

        [Test]
        public void ShouldThrowArgumentExceptionWhenUserDoesNotExist()
        {
            var username = _chance.Sentence();

            var beginDate = DateTime.MinValue;

            var endDate = DateTime.MaxValue;

            User userInDatabase = null;

            _userRepository.GetUser(Arg.Any<string>()).Returns(userInDatabase);

            Action getUserWeighInCall = () => _subjectUnderTest.GetUserWeighIns(username, beginDate, endDate);

            getUserWeighInCall.Should().Throw<ArgumentException>()
                .WithMessage($"{username} does not exist in the database.");
        }

        [Test]
        public void ShouldGetUserWeighInsWhenUsernameIsValid()
        {
            var username = _chance.Sentence();

            var beginDate = DateTime.MinValue;

            var endDate = DateTime.MaxValue;

            var userInDatabase = GetValidUser();

            _userRepository.GetUser(Arg.Any<string>()).Returns(userInDatabase);

            _subjectUnderTest.GetUserWeighIns(username, beginDate, endDate);

            _userRepository.Received(1).GetUserWeighIns(Arg.Any<string>(), Arg.Any<DateTime>(), Arg.Any<DateTime>());
        }
    }
}
