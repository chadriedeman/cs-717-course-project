using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using WeightTrackerApi.DTOs;

namespace WeightTrackerApi.Tests.ApiTests.ControllerTests.UserControllerTests
{
    public class AddUserTests : UserControllerTestsBase
    {
        [Test]
        public void ShouldReturnBadRequestWhenUserDtoIsNull()
        {
            UserDto nullUserDto = null;

            var response = _subjectUnderTest.AddUser(nullUserDto);

            response.Should().BeOfType<BadRequestObjectResult>();
        }

        [Test]
        public void ShouldReturnBadRequestWhenUserDtoIsInvalid()
        {
            var invalidUsername = string.Empty;

            var invalidUserDto = new UserDto
            {
                Username = invalidUsername
            };

            var response = _subjectUnderTest.AddUser(invalidUserDto);

            response.Should().BeOfType<BadRequestObjectResult>();
        }

        [Test]
        public void ShouldReturnConflictWhenUserAlreadyExists()
        {
            throw new NotImplementedException(); // TODO
        }

        [Test]
        public void ShouldReturnCreatedWhenUserDtoIsValid()
        {
            throw new NotImplementedException(); // TODO
        }
    }
}
