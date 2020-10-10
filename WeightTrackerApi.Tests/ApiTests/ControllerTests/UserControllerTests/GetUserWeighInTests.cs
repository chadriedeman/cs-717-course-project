using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using System;

namespace WeightTrackerApi.Tests.ApiTests.ControllerTests.UserControllerTests
{
    public class GetUserWeighInTests : UserControllerTestsBase
    {
        [Test]
        public void ShouldReturnBadRequestWhenInputsAreInvalid()
        {
            var username = _chance.Word();

            var date = _chance.Date();

            _userService.GetUserWeighIn(Arg.Any<string>(), Arg.Any<DateTime>())
                .Returns(callInfo => { throw new ArgumentException(); });

            var response = _subjectUnderTest.GetUserWeighIn(username, date);

            response.Should().BeOfType<BadRequestObjectResult>();
        }

        [Test]
        public void ShouldReturnWeighInWhenInputsAreValid()
        {
            var username = _chance.Word();

            var date = _chance.Date();

            var response = _subjectUnderTest.GetUserWeighIn(username, date);

            response.Should().BeOfType<OkObjectResult>();
        }
    }
}
