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
                BirthDate = userDto.BirthDate,
                Address = new UserAddress(userDto.Street, userDto.PostalCode, userDto.Province, userDto.Country),
                DeliveryAddress = new UserAddress("","","","")

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
                BirthDate = user.BirthDate,
                Street = (user.Address != null) ? user.Address.Street : string.Empty,
                Province = (user.Address != null) ? user.Address.Province : string.Empty,
                PostalCode = (user.Address != null) ? user.Address.PostalCode : string.Empty,
                Country = (user.Address != null) ? user.Address.Country : string.Empty

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
            foreach (var userItem in userAll)
            {
                usersDto.Add(new UserDto
                {
                    Id = userItem.Id,
                    BirthDate = userItem.BirthDate,
                    Name = userItem.Name,
                    Street = (userItem.Address != null) ? userItem.Address.Street : string.Empty,
                    Province = (userItem.Address != null) ? userItem.Address.Province : string.Empty,
                    PostalCode = (userItem.Address != null) ? userItem.Address.PostalCode : string.Empty,
                    Country = (userItem.Address != null) ? userItem.Address.Country : string.Empty
                });
            }
            return usersDto.AsEnumerable();
        }
    }
}
