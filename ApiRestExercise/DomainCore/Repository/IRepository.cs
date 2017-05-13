using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore.Repository
{
    /// <summary>
    /// Interfaz de la que herederan todas las interfazces de los repositorios
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IRepository<TModel> where TModel : class
    {
        /// <summary>
        /// Obtener todos los registros de una entidad sin tracking
        /// </summary>
        /// <returns></returns>
        IQueryable<TModel> GetAll();
        /// <summary>
        /// Obtener todos los registros de una entidad con tracking
        /// </summary>
        /// <returns></returns>
        IQueryable<TModel> GetAllWithTracking();
        /// <summary>
        /// Añadir una entidad al contexto de datos
        /// </summary>
        /// <param name="entityToAdd"></param>
        void Add(TModel entityToAdd);
        /// <summary>
        /// Actualizar una entidad en el contexto de datos
        /// </summary>
        /// <param name="entityToUpdate"></param>
        void Update(TModel entityToUpdate);
        /// <summary>
        /// Eliminar una entidad del contexto de datos
        /// </summary>
        /// <param name="entityToDelete"></param>
        void Delete(TModel entityToDelete);

    }

}
