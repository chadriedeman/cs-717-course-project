using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;

namespace WeightTrackerApi.Tests.ApiTests.ControllerTests.UserControllerTests
{
    public class DeleteUserTests : UserControllerTestsBase
    {
        [Test]
        public void ShouldDeleteUserAndReturnNoContent()
        {
            var username = _chance.Word();

            var response = _subjectUnderTest.DeleteUser(username);

            response.Should().BeOfType<NoContentResult>();

            _userService.Received(1).DeleteUser(Arg.Any<string>());
        }
    }
}
