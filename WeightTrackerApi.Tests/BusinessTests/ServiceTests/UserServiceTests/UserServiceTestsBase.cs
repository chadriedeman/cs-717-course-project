using ChanceNET;
using NSubstitute;
using System.Collections.Generic;
using WeightTrackerApi.Business.Services;
using WeightTrackerApi.DataAccess.Repositories;
using WeightTrackerApi.Domain.Enumerations;
using WeightTrackerApi.Domain.Models;

namespace WeightTrackerApi.Tests.BusinessTests.ServiceTests.UserServiceTests
{
    public abstract class UserServiceTestsBase
    {
        protected readonly Chance _chance;
        protected readonly IUserRepository _userRepository;
        protected readonly UserService _subjectUnderTest;

        protected UserServiceTestsBase()
        {
            _chance = new Chance();
            _userRepository = Substitute.For<IUserRepository>();
            _subjectUnderTest = new UserService(_userRepository);
        }

        protected User GetValidUser()
        {
            return new User
            {
                Id = _chance.Natural(),
                Username = _chance.Sentence(),
                FirstName = _chance.Sentence(),
                LastName = _chance.Sentence(),
                WeighIns = new List<WeighIn>()
            };
        }

        protected WeighIn GetValidWeighIn()
        {
            return new WeighIn
            {
                Id = _chance.Natural(),
                UserId = _chance.Natural(),
                Weight = _chance.Double(),
                Date = _chance.Date(),
                UnitOfMeasurement = UnitOfMeasurement.Pounds
            };
        }
    }
}
