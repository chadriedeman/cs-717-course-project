using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using System;

namespace WeightTrackerApi.Tests.ApiTests.ControllerTests.UserControllerTests
{
    public class GetUserWeighInsTests : UserControllerTestsBase
    {
        [Test]
        public void ShouldReturnBadRequestWhenInputsAreInvalid()
        {
            var username = _chance.Word();

            var beginDate = DateTime.MinValue;

            var endDate = DateTime.MaxValue;

            _userService.GetUserWeighIns(Arg.Any<string>(), Arg.Any<DateTime>(), Arg.Any<DateTime>())
                .Returns(callInfo => { throw new ArgumentException(); });

            var response = _subjectUnderTest.GetUserWeighIns(username, beginDate, endDate);

            response.Should().BeOfType<BadRequestObjectResult>();
        }

        [Test]
        public void ShouldReturnWeighInWhenInputsAreValid()
        {
            var username = _chance.Word();

            var beginDate = DateTime.MinValue;

            var endDate = DateTime.MaxValue;

            var response = _subjectUnderTest.GetUserWeighIns(username, beginDate, endDate);

            response.Should().BeOfType<OkObjectResult>();
        }
    }
}
