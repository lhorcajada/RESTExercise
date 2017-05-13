using ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.UserContracts
{
    public interface IDeleteUserService
    {
        /// <summary>
        /// Servicio que se encarga de orquestar la acción de eliminar un usuario
        /// </summary>
        /// <param name="user">Identificador del usuario</param>
        /// <returns></returns>
        Task DeleteUser(UserDto userDto);
        
    }
}
