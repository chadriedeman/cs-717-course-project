using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using WeightTrackerApi.Domain.Models;
using WeightTrackerApi.DTOs;
using WeightTrackerApi.Mappers;

namespace WeightTrackerApi.Tests.ApiTests.MapperTests
{
    public class UserMapperTests : MapperTestsBase
    {
        [Test]
        public void ShouldMapUserToUserDto()
        {
            var user = new User
            {
                Id = _chance.Natural(),
                Username = _chance.Sentence(),
                FirstName = _chance.Sentence(),
                LastName = _chance.Sentence(),
                WeighIns = new List<WeighIn>()
            };

            var expected = new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                WeighIns = new List<WeighInDto>()
            };

            var actual = UserMapper.MapUserToUserDto(user);

            expected.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void ShouldMapUserDtoToUser()
        {
            var userDto = new UserDto
            {
                Id = _chance.Natural(),
                Username = _chance.Sentence(),
                FirstName = _chance.Sentence(),
                LastName = _chance.Sentence(),
                WeighIns = new List<WeighInDto>()
            };

            var expected = new User
            {
                Id = userDto.Id,
                Username = userDto.Username,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                WeighIns = new List<WeighIn>()
            };

            var actual = UserMapper.MapUserDtoToUser(userDto);

            expected.Should().BeEquivalentTo(actual);
        }
    }
}
