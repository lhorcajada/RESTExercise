using System;
using System.Linq;
using DomainCore.Logic.UserLogic;
using DomainEntities;
using CrossCutting.Resources;

namespace DomainLogic.Logic.UserLogic

{
    /// <summary>
    /// Lógica para el mantenimiento de usuarios
    /// </summary>
    public class DeleteUserLogic : IDeleteUserLogic
    {
        public readonly IGetUserLogic _getUserLogic;
        /// <summary>
        /// Contructor que establece el objeto que maneja la obtención del usuario a eliminar.
        /// </summary>
        /// <param name="getUserLogic"></param>
        public DeleteUserLogic(IGetUserLogic getUserLogic)
        {
            if (getUserLogic == null)
                throw new ArgumentNullException(Resource.ExceptionNullObject);
            _getUserLogic = getUserLogic;

        }
        /// <summary>
        /// Orquesta la lógica para eliminar un usuario
        /// </summary>
        /// <param name="userAll"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public IQueryable<User> LogicToDelete(IQueryable<User> userAll, int id)
        {
            return _getUserLogic.QueryToGetUserById(userAll, id);
        }
    }
}
