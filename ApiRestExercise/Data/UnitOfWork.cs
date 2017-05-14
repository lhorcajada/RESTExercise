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
        private ExerciseContext _mainContext;
        protected ExerciseContext MainContext => _mainContext ?? (_mainContext = _dataFactory.GetContext());

        /// <summary>
        /// Constructor de la unidad de trabajo.
        /// </summary>
        /// <param name="dataFactory">Factoría que crea el contexto de datos</param>
        public UnitOfWork(IDataFactory dataFactory)
        {
            _dataFactory = dataFactory;
        }
        public void Dispose()
        {

        }
        /// <summary>
        /// Ejecuta la transacción en base de datos.
        /// </summary>
        public int Commit()
        {
            return MainContext.SaveChanges();
        }
        public async Task<int> CommitAsync()
        {
            return await MainContext.SaveChangesAsync();
        }

    }
}
