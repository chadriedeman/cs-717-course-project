using FluentValidation;
using WeightTrackerApi.DTOs;

namespace WeightTrackerApi.Validators
{
    public class WeighInDtoValidator : AbstractValidator<WeighInDto>
    {
        public WeighInDtoValidator()
        {
            RuleFor(weighInDto => weighInDto.UserId).GreaterThan(0);
        }
    }
}
