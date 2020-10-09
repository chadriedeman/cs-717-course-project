using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using System;

namespace WeightTrackerApi.Tests.ApiTests.ControllerTests.UserControllerTests
{
    public class DeleteUserWeighInTests : UserControllerTestsBase
    {
        [Test]
        public void ShouldDeleteWeighInAndReturnNoContent()
        {
            var username = _chance.Word();

            var date = _chance.Date();

            var response = _subjectUnderTest.DeleteUserWeighIn(username, date);

            response.Should().BeOfType<NoContentResult>();

            _userService.Received(1).DeleteUserWeighIn(Arg.Any<string>(), Arg.Any<DateTime>());
        }
    }
}
