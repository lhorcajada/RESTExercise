using System;
using System.Linq;
using ApplicationCore.DTOs;
using DomainCore.Logic.UserLogic;
using DomainEntities;
using CrossCutting.Resources;

namespace DomainLogic.Logic.UserLogic
{
    /// <summary>
    /// Lógica para el mantenimiento de usuarios
    /// </summary>
    public class UpdateUserLogic : IUpdateUserLogic
    {
        public readonly IUpdateUserRule _userRules;
        public readonly IGetUserLogic _getUserLogic;
        /// <summary>
        /// Contructor que establece los objetos que maneja las reglas para actualizar y obtener un usuario.
        /// </summary>
        /// <param name="userRules">Objeto que maneja las reglas para actualizar un usuario.</param>
        /// <param name="getUserLogic">Objeto que maneja las lógica para obtener un usuario.</param>
        public UpdateUserLogic(IUpdateUserRule userRules, IGetUserLogic getUserLogic)
        {
            if (userRules == null || getUserLogic == null)
                throw new ArgumentNullException(Resource.ExceptionNullObject);
            _userRules = userRules;
            _getUserLogic = getUserLogic;
        }
        /// <summary>
        /// Gestiona la lógica para actualizar un usuario en base de datos.
        /// </summary>
        /// <param name="userAll">Queryable con la query que obtiene todos los usuarios</param>
        /// <param name="user">Usuario que se va a actualizar</param>
        /// <returns></returns>
        public IQueryable<User> LogicToUpdate(IQueryable<User> userAll, UserDto user)
        {
            _userRules.ApplyRules(userAll, user);
            return _getUserLogic.QueryToGetUserById(userAll, user.Id);

        }
    }
}
