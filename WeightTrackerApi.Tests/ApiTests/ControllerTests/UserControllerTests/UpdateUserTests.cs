using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using WeightTrackerApi.Domain.Models;
using WeightTrackerApi.DTOs;

namespace WeightTrackerApi.Tests.ApiTests.ControllerTests.UserControllerTests
{
    public class UpdateUserTests : UserControllerTestsBase
    {
        [Test]
        public void ShouldReturnBadRequestWhenUserIsNull()
        {
            UserDto nullUser = null;

            var response = _subjectUnderTest.UpdateUser(nullUser);

            response.Should().BeOfType<BadRequestObjectResult>();

            _userService.DidNotReceive().UpdateUser(Arg.Any<User>());
        }

        [Test]
        public void ShouldReturnBadRequestWhenUserIsInvalid()
        {
            var invalidUsername = string.Empty;

            var invalidUser = new UserDto
            {
                Username = invalidUsername
            };

            var response = _subjectUnderTest.UpdateUser(invalidUser);

            response.Should().BeOfType<BadRequestObjectResult>();

            _userService.DidNotReceive().UpdateUser(Arg.Any<User>());
        }

        [Test]
        public void ShouldUpdateUserAndRetunNoContentWhenInputsAreValid()
        {
            var user = GetValidUserDto();

            var response = _subjectUnderTest.UpdateUser(user);

            response.Should().BeOfType<NoContentResult>();

            _userService.Received(1).UpdateUser(Arg.Any<User>());
        }
    }
}
