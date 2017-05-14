using ApplicationCore.DTOs;
using CrossCutting.Exceptions;
using CrossCutting.Resources;
using DomainCore.Logic.UserLogic;
using DomainEntities;
using System.Linq;

namespace DomainLogic.Rules.UserRules
{
    /// <summary>
    /// Maneja las reglas que se deben cumplir para añadir un usuario en base de datos.
    /// </summary>
    public class UpdateUserRule : UserBaseRule, IUpdateUserRule
    {
        public override void ApplyRules(IQueryable<User> userAll, UserDto userToUpdate)
        {
            this.CanNotRepeatUserName(userAll, userToUpdate);
            this.UserMustBeLegalAge(userToUpdate);
        }
        /// <summary>
        /// No se puede repetir el nombre quitando el usuario que se pretende actualizar.
        /// </summary>
        /// <param name="userAll"></param>
        /// <param name="userToUpdate"></param>
        public override void CanNotRepeatUserName(IQueryable<User> userAll, UserDto userToUpdate)
        {
            if (userAll.Any(u => u.Name.Contains(userToUpdate.Name) && u.Id != userToUpdate.Id))
                throw new BusinessException(Resource.ExceptionUserNameNoRepeat);

        }
    }
}
