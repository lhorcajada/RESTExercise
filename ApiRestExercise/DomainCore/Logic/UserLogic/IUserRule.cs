using ApplicationCore.DTOs;
using DomainEntities;
using System.Linq;

namespace DomainCore.Logic.UserLogic
{
    public interface IUserRule
    {
        /// <summary>
        /// Aplica todas las reglas que se deben cumplir para añadir un usuario.
        /// </summary>
        /// <param name="userAll">Query sin tracking para obtener todos los usuarios</param>
        /// <param name="userToAdd">Objeto usuario que se quiere dar de alta en base de datos</param>
        void ApplyRules(IQueryable<User> userAll, UserDto userToAdd);
    }
}
