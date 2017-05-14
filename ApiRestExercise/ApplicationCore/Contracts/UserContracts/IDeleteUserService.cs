using System.Threading.Tasks;

namespace ApplicationCore.Contracts.UserContracts
{
    public interface IDeleteUserService
    {
        /// <summary>
        /// Servicio que se encarga de orquestar la acción de eliminar un usuario
        /// </summary>
        /// <param name="id">Identificador del usuario</param>
        /// <returns></returns>
        Task DeleteUser(int id);
        
    }
}
