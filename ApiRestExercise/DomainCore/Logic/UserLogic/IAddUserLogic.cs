using ApplicationCore.DTOs;
using DomainEntities;
using System.Linq;

namespace DomainCore.Logic.UserLogic
{
    public interface IAddUserLogic
    {
        /// <summary>
        /// Lógica para añadir un usuario en base de datos
        /// </summary>
        /// <param name="userAll">Query sin tracking para obtener todos los usuarios</param>
        /// <param name="userDto">Objeto del usuario que se quiere dar de alta en base de datos</param>
        void LogicToAdd(IQueryable<User> userAll, UserDto userDto);

    }
}
