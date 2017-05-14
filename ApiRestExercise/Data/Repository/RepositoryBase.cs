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
        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbset.AsNoTracking().AsQueryable();
        }
        public virtual IQueryable<TEntity> GetAllWithTracking()
        {
            return _dbset.AsQueryable();
        }
        public virtual void Add(TEntity entityToAdd)
        {
            _dbset.Add(entityToAdd);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _dbset.Attach(entityToUpdate);
            _mainContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            _dbset.Remove(entityToDelete);
        }
      
    
    }

}
