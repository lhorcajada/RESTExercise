using System.Threading.Tasks;
using DomainCore.Repository;
using DomainCore.Logic.UserLogic;
using ApplicationCore.Contracts.UserContracts;
using System.Linq;
using System;
using CrossCutting.Resources;

namespace ApplicationServices.ManagementUser
{
    /// <summary>
    /// Servicio que orquesta las acciones para mantener un usuario.
    /// </summary>
    public class DeleteUserService : IDeleteUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserRepository _userRepository;
        private readonly IDeleteUserLogic _userLogic;
        public DeleteUserService(
            IUnitOfWork uow,
            IUserRepository userRepository,
            IDeleteUserLogic userLogic
            )
        {
            if (uow == null || userRepository == null || userLogic == null)
                throw new ArgumentNullException(Resource.ExceptionNullObject);
            _uow = uow;
            _userRepository = userRepository;
            _userLogic = userLogic;
        }



        public async Task DeleteUser(int id)
        {
            var userAll =  _userRepository.GetAllWithTracking();
            var user = _userLogic.ValidationsToDelete(userAll, id).FirstOrDefault();
            
            _userRepository.Delete(user);
            await _uow.CommitAsync();
        }
    }
}
