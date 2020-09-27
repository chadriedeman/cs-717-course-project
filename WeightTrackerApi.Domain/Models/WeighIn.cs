using System;
using WeightTrackerApi.Domain.Enumerations;

namespace WeightTrackerApi.Domain.Models
{
    public class WeighIn
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
    }
}
