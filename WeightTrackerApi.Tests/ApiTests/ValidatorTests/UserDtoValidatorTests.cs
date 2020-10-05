using FluentAssertions;
using NUnit.Framework;
using WeightTrackerApi.DTOs;
using WeightTrackerApi.Validators;

namespace WeightTrackerApi.Tests.ApiTests.ValidatorTests
{
    public class UserDtoValidatorTests : ValidatorTestsBase
    {
        private readonly UserDtoValidator _userDtoValidator;

        public UserDtoValidatorTests()
        {
            _userDtoValidator = new UserDtoValidator();
        }

        [Test]
        public void ShouldBeInvalidWhenUsernameIsNull()
        {
            string username = null;

            var user = new UserDto
            {
                Username = username
            };

            _userDtoValidator.Validate(user)
                .IsValid
                .Should()
                .BeFalse();
        }

        [Test]
        public void ShouldBeInvalidWhenUsernameIsEmpty()
        {
            var username = string.Empty;

            var user = new UserDto
            {
                Username = username
            };

            _userDtoValidator.Validate(user)
                .IsValid
                .Should()
                .BeFalse();
        }

        [Test]
        public void ShouldBeValidForValidUser()
        {
            var user = new UserDto
            {
                Username = _chance.Sentence()
            };

            _userDtoValidator.Validate(user)
                .IsValid
                .Should()
                .BeTrue();
        }
    }
}
