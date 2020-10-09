using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using System;
using WeightTrackerApi.Mappers;

namespace WeightTrackerApi.Tests.ApiTests.ControllerTests.UserControllerTests
{
    public class GetUserTests : UserControllerTestsBase
    {
        [Test]
        public void ShouldReturnBadRequestWhenUserDoesNotExist()
        {
            _userService
                .When(userService => userService.GetUser(Arg.Any<string>()))
                .Throw(new ArgumentException());

            var username = _chance.Word();

            var response = _subjectUnderTest.GetUser(username);

            response.Should().BeOfType<BadRequestObjectResult>();

            _userService.Received(1).GetUser(Arg.Any<string>());
        }

        [Test]
        public void ShouldReturnOkWhenUsernameIsValid()
        {
            var expected = GetValidUserDto();

            var user = UserMapper.MapUserDtoToUser(expected);

            _userService.GetUser(Arg.Any<string>()).Returns(user);

            var username = _chance.Word();

            var response = _subjectUnderTest.GetUser(username);

            var actual = ((OkObjectResult)response).Value;

            response.Should().BeOfType<OkObjectResult>();

            actual.Should().BeEquivalentTo(expected);

            _userService.Received(1).GetUser(Arg.Any<string>());
        }
    }
}
