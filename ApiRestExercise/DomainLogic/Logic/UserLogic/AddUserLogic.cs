using ApplicationCore.DTOs;
using CrossCutting.Exceptions;
using CrossCutting.Resources;
using DomainCore.Logic.UserLogic;
using DomainEntities;
using System;
using System.Linq;

namespace DomainLogic.Logic.UserLogic
{
    /// <summary>
    /// Lógica para el mantenimiento de usuarios
    /// </summary>
    public class AddUserLogic : IAddUserLogic
    {
        public readonly IAddUserRule _userRules;
        /// <summary>
        /// Contructor que establece el objeto que maneja las reglas para añadir un usuario.
        /// </summary>
        /// <param name="userRules">Objeto que maneja las reglas para añadir un usuario.</param>
        public AddUserLogic(IAddUserRule userRules)
        {
            if (userRules == null)
                throw new ArgumentNullException(Resource.ExceptionNullObject);
            _userRules = userRules;
        }

        /// <summary>
        /// Gestiona la lógica para añadir un usuario en base de datos.
        /// </summary>
        /// <param name="userAll">Queryable con la query que obtiene todos los usuarios</param>
        /// <param name="user">Usuario que se va a añadir</param>
        public void LogicToAdd(IQueryable<User> userAll, UserDto user)
        {
            if (user == null)
                throw new BusinessException(Resource.ExceptionUserNull);
            _userRules.ApplyRules(userAll, user);


        }

 
    }
}
