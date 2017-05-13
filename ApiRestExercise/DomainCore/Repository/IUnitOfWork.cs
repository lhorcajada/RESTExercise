using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore.Repository
{
    /// <summary>
    /// Interfaz que implementa la clase que maneja los repositorios para que la se mantenga la persistencia
    /// de varios repositorios en una misma transacción.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Ejecuta la transacción en base de datos en el hilo primario de la aplicación
        /// </summary>
        /// <returns></returns>
        int Commit();
        /// <summary>
        /// Ejecuta la transacción en base de datos en un hilo secundario.
        /// </summary>
        /// <returns></returns>
        Task<int> CommitAsync();

    }
}
