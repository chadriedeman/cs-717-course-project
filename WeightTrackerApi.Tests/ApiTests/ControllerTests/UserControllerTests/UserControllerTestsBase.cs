using ChanceNET;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Collections.Generic;
using WeightTrackerApi.Business.Services;
using WeightTrackerApi.Controllers;
using WeightTrackerApi.DTOs;

namespace WeightTrackerApi.Tests.ApiTests.ControllerTests.UserControllerTests
{
    public abstract class UserControllerTestsBase
    {
        protected readonly Chance _chance;
        protected readonly IUserService _userService;
        protected readonly ILogger<UserController> _logger;
        protected readonly UserController _subjectUnderTest;

        protected UserControllerTestsBase()
        {
            _chance = new Chance();
            _userService = Substitute.For<IUserService>();
            _logger = Substitute.For<ILogger<UserController>>();
            _subjectUnderTest = new UserController(_userService, _logger);
        }

        protected UserDto GetValidUserDto()
        {
            return new UserDto
            {
                Username = _chance.Word(),
                FirstName = _chance.Word(),
                LastName = _chance.Word(),
                WeighIns = new List<WeighInDto>()
            };
        }
    }
}
