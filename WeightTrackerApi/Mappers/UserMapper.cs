using WeightTrackerApi.Domain.Models;
using WeightTrackerApi.DTOs;

namespace WeightTrackerApi.Mappers
{
    public static class UserMapper
    {
        public static User MapUserDtoToUser(UserDto userDto)
        {
            return new User
            {
                Id = userDto.Id,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Username = userDto.Username,
                // TODO: WeighIns
            };
        }

        public static UserDto MapUserToUserDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                // TODO: WeighIns
            };
        }
    }
}
