using System.Collections.Generic;

namespace WeightTrackerApi.Domain.Models
{
    public class User
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<WeighIn> WeighIns { get; set; }
    }
}
