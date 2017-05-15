using Data.Model;
using DomainCore.Repository;
using System.Data.Entity;
using System.Linq;

namespace Data.Repository
{
    /// <summary>
    /// Clase base que implementa los métodos de persistencia y obtención más comunes.
    /// Todos los repositorios usarán esta clase base.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private ExerciseContext _mainContext;
        private readonly IDbSet<TEntity> _dbset;
        protected IDataFactory DataFactory
        {
            get;
            private set;
        }
        protected ExerciseContext MainContext
        {
            get { return _mainContext ?? (_mainContext = DataFactory.GetContext()); }
        }
        protected RepositoryBase(IDataFactory dataFactory)
        {
            DataFactory = dataFactory;
            _dbset = MainContext.Set<TEntity>();
        }
        /// <summary>
        /// Obtiene Queryable de una entidad que devolvería todos los registros.
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbset.AsNoTracking().AsQueryable();
        }
        /// <summary>
        /// Obtiene Queryable de una entidad con tracking que devolvería todos los registros.
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetAllWithTracking()
        {
            return _dbset.AsQueryable();
        }
        /// <summary>
        /// Añade una entidad al contexto de datos con el estado Añadir.
        /// </summary>
        /// <param name="entityToAdd">Entidad a añadir en el contexto de datos.</param>
        public virtual void Add(TEntity entityToAdd)
        {
            _dbset.Add(entityToAdd);
        }
        /// <summary>
        /// Añade una entidad al contexto de datos con el estado Modificar.
        /// </summary>
        /// <param name="entityToUpdate">Entidad a añadir al contexto de datos.</param>
        public virtual void Update(TEntity entityToUpdate)
        {
            _dbset.Attach(entityToUpdate);
            _mainContext.Entry(entityToUpdate).State = EntityState.Modified;
        }
        /// <summary>
        /// Añade una entidad al contexto de datos con el estado Eliminar.
        /// </summary>
        /// <param name="entityToDelete">Entidad a añadir al contexto de datos.</param>
        public virtual void Delete(TEntity entityToDelete)
        {
            _dbset.Remove(entityToDelete);
        }
      
    
    }

}
