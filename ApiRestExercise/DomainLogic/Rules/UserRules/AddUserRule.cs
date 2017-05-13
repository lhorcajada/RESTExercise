using ApplicationCore.DTOs;
using CrossCutting.Exceptions;
using CrossCutting.Resources;
using DomainCore.Logic.UserLogic;
using DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.Rules.UserRules
{
    /// <summary>
    /// Maneja las reglas que se deben cumplir para añadir un usuario en base de datos.
    /// </summary>
    public class AddUserRule : UserBaseRule, IUserRule
    {
        public override void ApplyRules(IQueryable<User> userAll, UserDto userToAdd)
        {
            this.CanNotRepeatUserName(userAll, userToAdd);
            this.UserMustBeLegalAge(userToAdd);
        }
    }
}
