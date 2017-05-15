using ApplicationCore.DTOs;
using CrossCutting.Exceptions;
using CrossCutting.Resources;
using DomainEntities;
using System;
using System.Linq;

namespace DomainLogic.Rules.UserRules
{
    public abstract class UserBaseRule
    {
        /// <summary>
        /// Aplica las reglas antes de realizar cualquier acción sobre el usuario en base de datos 
        /// </summary>
        /// <param name="userAll">Queryable con la query que obtiene todos los usuarios</param>
        /// <param name="user">Usuario sobre el que se aplican las reglas.</param>
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
