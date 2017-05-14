using System;
using System.Linq;
using ApplicationCore.DTOs;
using DomainCore.Logic.UserLogic;
using DomainEntities;
using DomainLogic.Logic.UserLogic;
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
        public UpdateUserLogic(IUpdateUserRule userRules, IGetUserLogic getUserLogic)
        {
            if (userRules == null || getUserLogic == null)
                throw new ArgumentNullException(Resource.ExceptionNullObject);
            _userRules = userRules;
            _getUserLogic = getUserLogic;
        }

        public IQueryable<User> ValidationsToUpdate(IQueryable<User> userAll, UserDto user)
        {
            _userRules.ApplyRules(userAll, user);
            return _getUserLogic.QueryToGetUserById(userAll, user.Id);

        }
    }
}
