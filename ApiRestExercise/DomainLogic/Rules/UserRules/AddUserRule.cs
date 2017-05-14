using ApplicationCore.DTOs;
using DomainCore.Logic.UserLogic;
using DomainEntities;
using System.Linq;

namespace DomainLogic.Rules.UserRules
{
    /// <summary>
    /// Maneja las reglas que se deben cumplir para añadir un usuario en base de datos.
    /// </summary>
    public class AddUserRule : UserBaseRule, IAddUserRule
    {
        public override void ApplyRules(IQueryable<User> userAll, UserDto userToAdd)
        {
            this.CanNotRepeatUserName(userAll, userToAdd);
            this.UserMustBeLegalAge(userToAdd);
        }
    }
}
