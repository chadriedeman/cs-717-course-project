using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;

namespace WeightTrackerApi.Tests.ApiTests.ControllerTests.UserControllerTests
{
    public class GetUsersTests : UserControllerTestsBase
    {
        [Test]
        public void ShouldDeleteUserAndReturnNoContent()
        {
            var response = _subjectUnderTest.GetUsers();

            response.Should().BeOfType<OkObjectResult>();

            _userService.Received(1).GetUsers();
        }
    }
}
