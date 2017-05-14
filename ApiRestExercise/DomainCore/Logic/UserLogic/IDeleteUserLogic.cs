using ApplicationCore.DTOs;
using DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore.Logic.UserLogic
{
    public interface IDeleteUserLogic
    {
        /// <summary>
        /// Lógica para eliminar un usuario en base de datos
        /// </summary>
        /// <param name="userAll">Query con tracking par obtener todos los usuarios</param>
        /// <param name="id">identificador</param>
        IQueryable<User> ValidationsToDelete(IQueryable<User> userAll, int id);
    }
}
