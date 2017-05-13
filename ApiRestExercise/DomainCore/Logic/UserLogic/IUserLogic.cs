using ApplicationCore.DTOs;
using DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore.Logic.UserLogic
{
    public interface IUserLogic
    {
        /// <summary>
        /// Lógica para obtener un usuario por su identificador
        /// </summary>
        /// <param name="userAll">Query sin tracking para obtener todos los usuarios</param>
        /// <param name="userId">Identificador del usuario que se quiere localizar.</param>
        /// <returns></returns>
        IQueryable<User> QueryToGetUserById(IQueryable<User> userAll, int userId);

        /// <summary>
        /// Lógica para añadir un usuario en base de datos
        /// </summary>
        /// <param name="userAll">Query sin tracking para obtener todos los usuarios</param>
        /// <param name="userDto">Objeto del usuario que se quiere dar de alta en base de datos</param>
        void ValidationsToAdd(IQueryable<User> userAll, UserDto userDto);
        void ValidationsToGetById(User userFinded);

        /// <summary>
        /// Lógica para eliminar un usuario en base de datos
        /// </summary>
        /// <param name="userAll">Query con tracking par obtener todos los usuarios</param>
        /// <param name="user">Objeto del usuario que se quiere eliminar en base de datos</param>
        IQueryable<User> ValidationsToDelete(IQueryable<User> userAll, UserDto user);
        /// <summary>
        /// Lógica para actualizar un usuario en base de datos
        /// </summary>
        /// <param name="userAll">Query con tracking para obtener todos los usuarios</param>
        /// <param name="user">Objeto del usuario que se quiere actualizar en base de datos</param>
        IQueryable<User> ValidationsToUpdate(IQueryable<User> userAll, UserDto user);



    }
}
