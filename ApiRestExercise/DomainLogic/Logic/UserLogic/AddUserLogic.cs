using ApplicationCore.DTOs;
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
        public AddUserLogic(IAddUserRule userRules)
        {
            if (userRules == null)
                throw new ArgumentNullException(Resource.ExceptionNullObject);
            _userRules = userRules;
        }


        public void ValidationsToAdd(IQueryable<User> userAll, UserDto user)
        {
            _userRules.ApplyRules(userAll, user);


        }

 
    }
}
