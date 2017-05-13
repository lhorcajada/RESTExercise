using ApplicationCore.DTOs;
using DomainEntities;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationServices.ManagemenUser
{
    public class MapperUser
    { 
        public static User MapFromDtoToEntity(UserDto userDto)
        {
            return new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                BirthDate = userDto.BirthDate
            };
        }
        public static UserDto MapFromEntityToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                BirthDate = user.BirthDate

            };
        }

        internal static IEnumerable<UserDto> MapFromEntityListToDtoList(List<User> userAll)
        {
            List<UserDto> usersDto = new List<UserDto>();
            foreach(var userItem in userAll)
            {
                usersDto.Add(new UserDto
                {
                    Id = userItem.Id,
                    BirthDate = userItem.BirthDate,
                    Name = userItem.Name
                });
            }
            return usersDto.AsEnumerable();
        }
    }
}
