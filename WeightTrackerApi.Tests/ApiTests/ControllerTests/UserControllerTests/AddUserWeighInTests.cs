using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WeightTrackerApi.Domain.Models;
using WeightTrackerApi.DTOs;

namespace WeightTrackerApi.Tests.ApiTests.ControllerTests.UserControllerTests
{
    public class AddUserWeighInTests : UserControllerTestsBase
    {
        [Test]
        public void ShouldReturnBadRequestWhenUsernameIsNull()
        {
            string nullUsername = null;

            var weighInDto = GetValidWeighInDto();

            var response = _subjectUnderTest.AddUserWeighIn(nullUsername, weighInDto);

            response.Should().BeOfType<BadRequestObjectResult>();
        }

        [Test]
        public void ShouldReturnBadRequestWhenUsernameIsEmpty()
        {
            string emptyUsername = string.Empty;

            var weighInDto = GetValidWeighInDto();

            var response = _subjectUnderTest.AddUserWeighIn(emptyUsername, weighInDto);

            response.Should().BeOfType<BadRequestObjectResult>();
        }

        [Test]
        public void ShouldReturnBadRequestWhenWeighInIsNull()
        {
            string username = _chance.Word();

            WeighInDto nullWeighInDto = null;

            var response = _subjectUnderTest.AddUserWeighIn(username, nullWeighInDto);

            response.Should().BeOfType<BadRequestObjectResult>();
        }

        [Test]
        public void ShouldReturnBadRequestWhenWeighInUserIdIsZero()
        {
            string username = _chance.Word();

            var invalidWeighInDto = GetValidWeighInDto();

            invalidWeighInDto.UserId = 0;

            var response = _subjectUnderTest.AddUserWeighIn(username, invalidWeighInDto);

            response.Should().BeOfType<BadRequestObjectResult>();
        }

        [Test]
        public void ShouldReturnConflictWhenWeighInAlreadyExists()
        {
            _userService
                .When(userService => userService.AddUserWeighIn(Arg.Any<string>(), Arg.Any<WeighIn>()))
                .Throw(new ArgumentException());

            var username = _chance.Word();

            var weighInDto = GetValidWeighInDto();

            var response = _subjectUnderTest.AddUserWeighIn(username, weighInDto);

            response.Should().BeOfType<ConflictObjectResult>();
        }

        [Test]
        public void ShouldReturnCreatedWhenUsernameAndWeighInDtoIsValid()
        {
            var username = _chance.Word();

            var weighInDto = GetValidWeighInDto();

            var response = _subjectUnderTest.AddUserWeighIn(username, weighInDto);

            response.Should().BeOfType<CreatedResult>();
        }
    }
}
