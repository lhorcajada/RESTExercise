using ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.UserContracts
{
    public interface IAddUserService
    {
        /// <summary>
        /// Servicio que se encarga de orquestar la acción de añadir un usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task AddUser(UserDto user);
        
    }
}
