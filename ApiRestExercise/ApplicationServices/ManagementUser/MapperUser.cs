using ApplicationCore.DTOs;
using DomainEntities;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationServices.ManagementUser
{
    /// <summary>
    /// Clase que se encarga de los mapeos entre entidades y dtos.
    /// </summary>
    public class MapperUser
    { 
        /// <summary>
        /// Mapea un objeto DTO a un nuevo objeto entidad
        /// </summary>
        /// <param name="userDto">Objeto DTO a mapear</param>
        /// <returns></returns>
        public static User MapFromDtoToEntity(UserDto userDto)
        {
            return new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                BirthDate = userDto.BirthDate
            };
        }
        /// <summary>
        /// Mapea un objeto entidad a un nuevo objeto DTO
        /// </summary>
        /// <param name="user">Objeto entidad de usuario a mapear.</param>
        /// <returns></returns>
        public static UserDto MapFromEntityToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                BirthDate = user.BirthDate

            };
        }
        /// <summary>
        /// Mapea un listado de entidades a un listado de DTOs.
        /// </summary>
        /// <param name="userAll">Listado de entidades a mapear.</param>
        /// <returns></returns>
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
