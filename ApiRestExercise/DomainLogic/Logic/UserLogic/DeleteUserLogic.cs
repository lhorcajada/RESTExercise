
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
        public DeleteUserLogic(IGetUserLogic getUserLogic)
        {
            if (getUserLogic == null)
                throw new ArgumentNullException(Resource.ExceptionNullObject);
            _getUserLogic = getUserLogic;

        }

        public IQueryable<User> ValidationsToDelete(IQueryable<User> userAll, int id)
        {
            return _getUserLogic.QueryToGetUserById(userAll, id);
        }
    }
}
