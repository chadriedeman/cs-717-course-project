using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using WeightTrackerApi.Domain.Enumerations;
using WeightTrackerApi.Domain.Models;
using WeightTrackerApi.DTOs;
using WeightTrackerApi.Mappers;

namespace WeightTrackerApi.Tests.ApiTests.MapperTests
{
    public class WeighInMapperTests : MapperTestsBase
    {
        [Test]
        public void ShouldMapWeighInToWeighInDto()
        {
            var weighIn = new WeighIn
            {
                Id = _chance.Natural(),
                UserId = _chance.Natural(),
                Date = _chance.Date(),
                Weight = _chance.Float(),
                UnitOfMeasurement = UnitOfMeasurement.Pounds
            };

            var expected = new WeighInDto
            {
                Id = weighIn.Id,
                UserId = weighIn.UserId,
                Date = weighIn.Date,
                Weight = weighIn.Weight,
                UnitOfMeasurement = weighIn.UnitOfMeasurement
            };

            var actual = WeighInMapper.MapWeighInToWeighInDto(weighIn);

            expected.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void ShouldMapWeighInDtoToWeighIn()
        {
            var weighInDto = new WeighInDto
            {
                Id = _chance.Natural(),
                UserId = _chance.Natural(),
                Date = _chance.Date(),
                Weight = _chance.Float(),
                UnitOfMeasurement = UnitOfMeasurement.Pounds
            };

            var expected = new WeighIn
            {
                Id = weighInDto.Id,
                UserId = weighInDto.UserId,
                Date = weighInDto.Date,
                Weight = weighInDto.Weight,
                UnitOfMeasurement = weighInDto.UnitOfMeasurement
            };

            var actual = WeighInMapper.MapWeighInDtoToWeighIn(weighInDto);

            expected.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void ShouldMapWeighInsToWeighInDtos()
        {
            var weighIns = new List<WeighIn>
            {
                new WeighIn
                {
                    Id = _chance.Natural(),
                    UserId = _chance.Natural(),
                    Date = _chance.Date(),
                    Weight = _chance.Float(),
                    UnitOfMeasurement = UnitOfMeasurement.Pounds
                }
            };

            var expected = new List<WeighInDto>
            {
                new WeighInDto
                {
                    Id = weighIns.First().Id,
                    UserId = weighIns.First().UserId,
                    Date = weighIns.First().Date,
                    Weight = weighIns.First().Weight,
                    UnitOfMeasurement = weighIns.First().UnitOfMeasurement
                }
            };

            var actual = WeighInMapper.MapWeighInsToWeighInDtos(weighIns);

            expected.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void ShouldMapWeighInDtosToWeighIns()
        {
            var weighInDtos = new List<WeighInDto>
            {
                new WeighInDto
                {
                    Id = _chance.Natural(),
                    UserId = _chance.Natural(),
                    Date = _chance.Date(),
                    Weight = _chance.Float(),
                    UnitOfMeasurement = UnitOfMeasurement.Pounds
                }
            };

            var expected = new List<WeighIn>
            {
                new WeighIn
                {
                    Id = weighInDtos.First().Id,
                    UserId = weighInDtos.First().UserId,
                    Date = weighInDtos.First().Date,
                    Weight = weighInDtos.First().Weight,
                    UnitOfMeasurement = weighInDtos.First().UnitOfMeasurement
                }
            };

            var actual = WeighInMapper.MapWeighInDtosToWeighIns(weighInDtos);

            expected.Should().BeEquivalentTo(actual);
        }
    }
}
