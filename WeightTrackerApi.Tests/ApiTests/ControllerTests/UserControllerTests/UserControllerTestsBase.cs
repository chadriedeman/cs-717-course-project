using ChanceNET;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using WeightTrackerApi.Business.Services;
using WeightTrackerApi.Controllers;
using WeightTrackerApi.Domain.Enumerations;
using WeightTrackerApi.DTOs;

namespace WeightTrackerApi.Tests.ApiTests.ControllerTests.UserControllerTests
{
    public abstract class UserControllerTestsBase
    {
        protected readonly Chance _chance;
        protected IUserService _userService;
        protected ILogger<UserController> _logger;
        protected UserController _subjectUnderTest;

        protected UserControllerTestsBase()
        {
            _chance = new Chance();
        }

        [SetUp]
        public void SetUp()
        {
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

        protected WeighInDto GetValidWeighInDto()
        {
            return new WeighInDto
            {
                Id = _chance.Natural(),
                UserId = _chance.Natural(),
                Date = _chance.Date(),
                Weight = _chance.Double(),
                UnitOfMeasurement = UnitOfMeasurement.Pounds
            };
        }
    }
}
