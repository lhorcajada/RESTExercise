using DomainCore.Repository;
using DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    /// <summary>
    /// Repositorio para obtener, crear, modificar y elminiar usuarios.
    /// El repositorio implementa su propia interfaz por si tiene la necesida de crear algún
    /// método que no se encuentre en el repositorio base.
    /// </summary>
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDataFactory dataFactory) : base(dataFactory)
        {
        }
    }
}
