using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeightTrackerApi.DTOs;

namespace WeightTrackerApi.Validators
{
    public class WeighInDtoValidator : AbstractValidator<WeighInDto>
    {
        public WeighInDtoValidator()
        {
            // TODO
        }
    }
}
