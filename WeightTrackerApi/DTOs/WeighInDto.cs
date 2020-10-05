using System;
using WeightTrackerApi.Domain.Enumerations;

namespace WeightTrackerApi.DTOs
{
    public class WeighInDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
    }
}
