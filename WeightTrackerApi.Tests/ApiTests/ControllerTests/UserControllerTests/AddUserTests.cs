using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using System;
using WeightTrackerApi.Domain.Models;
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
            _userService
                .When(userService => userService.AddUser(Arg.Any<User>()))
                .Throw(new ArgumentException());

            var userDto = GetValidUserDto();

            var response = _subjectUnderTest.AddUser(userDto);

            response.Should().BeOfType<ConflictObjectResult>();
        }

        [Test]
        public void ShouldReturnCreatedWhenUserDtoIsValid()
        {
            var userDto = GetValidUserDto();

            var response = _subjectUnderTest.AddUser(userDto);

            response.Should().BeOfType<CreatedResult>();
        }
    }
}
