using ApplicationCore.DTOs;
using DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore.Logic.UserLogic
{
    public interface IGetUserLogic
    {
        /// <summary>
        /// Lógica para obtener un usuario por su identificador
        /// </summary>
        /// <param name="userAll">Query sin tracking para obtener todos los usuarios</param>
        /// <param name="userId">Identificador del usuario que se quiere localizar.</param>
        /// <returns></returns>
        IQueryable<User> QueryToGetUserById(IQueryable<User> userAll, int userId);
        /// <summary>
        /// Validaciones para obtener un usuario por id.
        /// </summary>
        /// <param name="userFinded"></param>
        void ValidationsToGetById(User userFinded);

    }
}
