using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using WeightTrackerApi.Domain.Models;
using WeightTrackerApi.DTOs;

namespace WeightTrackerApi.Tests.ApiTests.ControllerTests.UserControllerTests
{
    public class UpdateUserWeighInTests : UserControllerTestsBase
    {
        [Test]
        public void ShouldReturnBadRequestWhenUsernameIsNull()
        {
            string nullUsername = null;

            var weighInDto = GetValidWeighInDto();

            var response = _subjectUnderTest.UpdateUserWeighIn(nullUsername, weighInDto);

            response.Should().BeOfType<BadRequestObjectResult>();

            _userService.DidNotReceive().UpdateUserWeighIn(Arg.Any<string>(), Arg.Any<WeighIn>());
        }

        [Test]
        public void ShouldReturnBadRequestWhenUsernameIsEmpty()
        {
            var emptyUsername = string.Empty;

            var weighInDto = GetValidWeighInDto();

            var response = _subjectUnderTest.UpdateUserWeighIn(emptyUsername, weighInDto);

            response.Should().BeOfType<BadRequestObjectResult>();

            _userService.DidNotReceive().UpdateUserWeighIn(Arg.Any<string>(), Arg.Any<WeighIn>());
        }

        [Test]
        public void ShouldReturnBadRequestWhenWeighInIsNull()
        {
            var username = _chance.Word();

            WeighInDto nullWeighInDto = null;

            var response = _subjectUnderTest.UpdateUserWeighIn(username, nullWeighInDto);

            response.Should().BeOfType<BadRequestObjectResult>();

            _userService.DidNotReceive().UpdateUserWeighIn(Arg.Any<string>(), Arg.Any<WeighIn>());
        }

        [Test]
        public void ShouldReturnBadRequestWhenWeighInIsInvalid()
        {
            var username = _chance.Word();

            var invalidUserId = -1;

            var invalidWeighInDto = new WeighInDto
            {
                UserId = invalidUserId
            };

            var response = _subjectUnderTest.UpdateUserWeighIn(username, invalidWeighInDto);

            response.Should().BeOfType<BadRequestObjectResult>();

            _userService.DidNotReceive().UpdateUserWeighIn(Arg.Any<string>(), Arg.Any<WeighIn>());
        }

        [Test]
        public void ShouldUpdateWeighInAndReturnNoContentWhenInputIsValid()
        {
            var username = _chance.Word();

            var weighInDto = GetValidWeighInDto();

            var response = _subjectUnderTest.UpdateUserWeighIn(username, weighInDto);

            response.Should().BeOfType<NoContentResult>();

            _userService.Received(1).UpdateUserWeighIn(Arg.Any<string>(), Arg.Any<WeighIn>());

        }
    }
}
