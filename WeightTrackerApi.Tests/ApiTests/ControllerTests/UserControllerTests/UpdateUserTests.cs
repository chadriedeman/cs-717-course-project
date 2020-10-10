using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using System;
using WeightTrackerApi.Domain.Models;

namespace WeightTrackerApi.Tests.ApiTests.ControllerTests.UserControllerTests
{
    public class UpdateUserTests : UserControllerTestsBase
    {
        [Test]
        public void ShouldReturnBadRequestWhenUserIsNull()
        {
            throw new NotImplementedException(); // TODO
        }

        [Test]
        public void ShouldReturnBadRequestWhenUserIsInvalid()
        {
            throw new NotImplementedException(); // TODO
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
