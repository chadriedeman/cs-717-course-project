using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;

namespace WeightTrackerApi.Tests.BusinessTests.ServiceTests.UserServiceTests
{
    public class GetUsersTests : UserServiceTestsBase
    {
        [Test]
        public void ShouldThrowArgumentExceptionWhenUsernameIsEmpty()
        {
            var emptyUsername = string.Empty;

            Action getUserCall = () => _subjectUnderTest.GetUser(emptyUsername);

            getUserCall.Should().Throw<ArgumentException>()
                .WithMessage("No username was provided to GetUser.");
        }

        [Test]
        public void ShouldGetUserWhenUsernameIsValid()
        {
            var username = _chance.Sentence();

            _subjectUnderTest.GetUser(username);

            _userRepository.Received(1).GetUser(Arg.Any<string>());
        }
    }
}
