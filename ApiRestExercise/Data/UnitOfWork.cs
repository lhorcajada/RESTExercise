using Data.Model;
using DomainCore.Repository;
using System;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Clase que se encarga de agrupar las tareas de persistencia en una única transacción.
    /// </summary>
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private readonly IDataFactory _dataFactory;
        private ExerciseContext _context;
        protected ExerciseContext MainContext => _context ?? (_context = _dataFactory.GetContext());

        /// <summary>
        /// Constructor de la unidad de trabajo.
        /// </summary>
        /// <param name="dataFactory">Factoría que crea el contexto de datos</param>
        public UnitOfWork(IDataFactory dataFactory)
        {
            _dataFactory = dataFactory;
        }
  
        /// <summary>
        /// Ejecuta la transacción en base de datos.
        /// Todas las entidades añadidas al contexto con el estado añadir, modificar o eliminar
        /// se ejecutarán a la vez.
        /// </summary>
        public int Commit()
        {
            return MainContext.SaveChanges();
        }
        /// <summary>
        /// Ejecuta la transacción asíncronamente en base de datos.
        /// Todas las entidades añadidas al contexto con el estado añadir, modificar o eliminar
        /// se ejecutarán a la vez.
        /// </summary>
        /// <returns></returns>
        public async Task<int> CommitAsync()
        {
            return await MainContext.SaveChangesAsync();
        }
        #region Implementación IDisposable.
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (this._context == null)
            {
                return;
            }

            this._context.Dispose();
            this._context = null;
        }
        #endregion

    }
}
