using System.Collections.Generic;

namespace WeightTrackerApi.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<WeighInDto> WeighIns { get; set; }
    }
}
