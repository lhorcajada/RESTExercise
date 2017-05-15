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
        /// <summary>
        /// Query para localizar un usuario por su identificador
        /// </summary>
        /// <param name="userAll">IQueryable con la query para obtener todos los usuarios</param>
        /// <param name="userId">Identificador del usuario buscado.</param>
        /// <returns></returns>
        public IQueryable<User> QueryToGetUserById(IQueryable<User> userAll, int userId)
        {
            return userAll.Where(u => u.Id == userId);
        }
        /// <summary>
        /// Valida si el usuario encontrado es nulo.
        /// </summary>
        /// <param name="userFound">Usuario encontrado en base de datos.</param>
        public void ValidateIfUserFoundIsNull(User userFound)
        {
            if (userFound == null)
                throw new BusinessException(Resource.ExceptionUserNotFound);
        }
    }
}
