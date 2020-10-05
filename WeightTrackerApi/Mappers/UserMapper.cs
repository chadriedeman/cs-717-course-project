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
                WeighIns = WeighInMapper.MapWeighInDtosToWeighIns(userDto.WeighIns)
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
                WeighIns = WeighInMapper.MapWeighInsToWeighInDtos(user.WeighIns)
            };
        }
    }
}
