using ApplicationCore.DTOs;
using CrossCutting.Exceptions;
using CrossCutting.Resources;
using DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.Rules.UserRules
{
    public abstract class UserBaseRule
    {
        public abstract void ApplyRules(IQueryable<User> userAll, UserDto user);
   

        /// <summary>
        /// No se puede repetir un nombre de usuario que ya exista en base de datos
        /// </summary>
        /// <param name="userAll">Lista de usuarios</param>
        /// <param name="name">Nombre de usuario que se pretende añadir.</param>
        public virtual void CanNotRepeatUserName(IQueryable<User> userAll, UserDto user)
        {
            if (userAll.Any(u => u.Name.Contains(user.Name)))
                throw new BusinessException(Resource.ExceptionUserNameNoRepeat);

        }
        /// <summary>
        /// El usuario debe ser mayor de edad.
        /// </summary>
        /// <param name="user"></param>
        public void UserMustBeLegalAge(UserDto user)
        {
            if (user.BirthDate.CalculateAge() < 18)
                throw new BusinessException(Resource.ExceptionUserMustBeLegalAge);


        }
    }
}
