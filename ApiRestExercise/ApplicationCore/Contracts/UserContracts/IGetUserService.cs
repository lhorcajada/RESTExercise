using ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.UserContracts
{
    /// <summary>
    /// Interfaz con todos los métodos de obtención de usuarios disponibles.
    /// </summary>
    public interface IGetUserService
    {
        /// <summary>
        /// Método que se encarga de orquestar la acción de actualizar un usuario
        /// </summary>
        /// <param name="id">Identificador del usuario</param>
        /// <returns></returns>
        Task<UserDto> GetUserById(int id);
        /// <summary>
        /// Método que obtiene todos los usuarios
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UserDto>> GetUserAll();

    }
}
