
using System;
using System.Linq;
using DomainCore.Logic.UserLogic;
using DomainEntities;
using CrossCutting.Exceptions;
using CrossCutting.Resources;

namespace DomainLogic.Logic.UserLogic
{
    /// <summary>
    /// Lógica para el mantenimiento de usuarios
    /// </summary>
    public class GetUserLogic : IGetUserLogic
    {
        public IQueryable<User> QueryToGetUserById(IQueryable<User> userAll, int userId)
        {
            return userAll.Where(u => u.Id == userId);
        }

        public void ValidationsToGetById(User userFinded)
        {
            if (userFinded == null)
                throw new BusinessException(Resource.ExceptionUserNotFound);
        }
    }
}
