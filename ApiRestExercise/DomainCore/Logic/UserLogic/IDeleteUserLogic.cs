using DomainEntities;
using System.Linq;

namespace DomainCore.Logic.UserLogic
{
    public interface IDeleteUserLogic
    {
        /// <summary>
        /// Lógica para eliminar un usuario en base de datos
        /// </summary>
        /// <param name="userAll">Query con tracking par obtener todos los usuarios</param>
        /// <param name="id">identificador</param>
        IQueryable<User> LogicToDelete(IQueryable<User> userAll, int id);
    }
}
