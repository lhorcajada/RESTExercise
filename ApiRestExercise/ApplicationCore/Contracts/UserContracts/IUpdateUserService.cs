using ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.UserContracts
{
    public interface IUpdateUserService
    {
        /// <summary>
        /// Servicio que se encarga de orquestar la acción de actualizar un usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task UpdateUser(UserDto user);
        
    }
}
