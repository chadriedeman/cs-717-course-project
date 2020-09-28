using FluentValidation;
using WeightTrackerApi.DTOs;

namespace WeightTrackerApi.Validators
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(user => user.Username).NotEmpty();

            // TODO
        }
    }
}
