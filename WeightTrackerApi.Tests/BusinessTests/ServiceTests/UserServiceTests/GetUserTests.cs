using NSubstitute;
using NUnit.Framework;

namespace WeightTrackerApi.Tests.BusinessTests.ServiceTests.UserServiceTests
{
    public class GetUserTests : UserServiceTestsBase
    {
        [Test]
        public void ShouldGetUsers()
        {
            _subjectUnderTest.GetUsers();

            _userRepository.Received(1).GetUsers();
        }
    }
}
