using FluentAssertions;
using NUnit.Framework;
using WeightTrackerApi.DTOs;
using WeightTrackerApi.Validators;

namespace WeightTrackerApi.Tests.ApiTests.ValidatorTests
{
    public class WeighInDtoValidatorTests : ValidatorTestsBase
    {
        private readonly WeighInDtoValidator _weighInDtoValidator;

        public WeighInDtoValidatorTests()
        {
            _weighInDtoValidator = new WeighInDtoValidator();
        }

        [Test]
        public void ShouldBeInvalidWhenUserIdIsZero()
        {
            var invalidUserId = 0;

            var invalidWeighInDto = new WeighInDto
            {
                UserId = invalidUserId
            };

            _weighInDtoValidator.Validate(invalidWeighInDto)
                .IsValid
                .Should()
                .BeFalse();
        }

        [Test]
        public void ShouldBeValidWhenWeighInDtoIsValid()
        {
            var validWeighInDto = new WeighInDto
            {
                UserId = _chance.Natural()
            };

            _weighInDtoValidator.Validate(validWeighInDto)
                .IsValid
                .Should()
                .BeTrue();
        }
    }
}
