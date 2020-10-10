using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;

namespace WeightTrackerApi.Tests.ApiTests.ControllerTests.UserControllerTests
{
    public class GetUserWeighInsTests : UserControllerTestsBase
    {
        [Test]
        public void ShouldReturnBadRequestWhenUserDoesNotExist()
        {
            throw new NotImplementedException(); // TODO
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
