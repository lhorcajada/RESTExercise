using DomainEntities;

namespace DomainCore.Repository
{
    /// <summary>
    /// Interfaz que implementa el repositorio de la entidad usuario. Hereda de IRepository que es la interfaz
    /// que tiene las firmas del repositorio base.
    /// </summary>
    public interface IUserRepository:IRepository<User>
    {
    }
}
