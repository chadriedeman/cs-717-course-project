using System.Collections.Generic;
using System.Linq;
using WeightTrackerApi.Domain.Models;
using WeightTrackerApi.DTOs;

namespace WeightTrackerApi.Mappers
{
    public static class WeighInMapper
    {
        public static WeighIn MapWeighInDtoToWeighIn(WeighInDto weighInDto)
        {
            return new WeighIn
            {
                Id = weighInDto.Id,
                UserId = weighInDto.UserId,
                Date = weighInDto.Date,
                Weight = weighInDto.Weight,
                UnitOfMeasurement = weighInDto.UnitOfMeasurement
            };
        }

        public static WeighInDto MapWeighInToWeighInDto(WeighIn weighIn)
        {
            return new WeighInDto
            {
                Id = weighIn.Id,
                UserId = weighIn.UserId,
                Date = weighIn.Date,
                Weight = weighIn.Weight,
                UnitOfMeasurement = weighIn.UnitOfMeasurement
            };
        }

        public static List<WeighIn> MapWeighInDtosToWeighIns(List<WeighInDto> weighInDtos)
        {
            if (weighInDtos == null)
                return null;

            return weighInDtos.Select(weighInDto => MapWeighInDtoToWeighIn(weighInDto))
                .ToList();
        }

        public static List<WeighInDto> MapWeighInsToWeighInDtos(List<WeighIn> weighIns)
        {
            if (weighIns == null)
                return null;

            return weighIns.Select(weighIn => MapWeighInToWeighInDto(weighIn))
                .ToList();
        }
    }
}
