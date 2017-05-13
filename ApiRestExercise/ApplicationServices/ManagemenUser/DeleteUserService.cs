using System.Threading.Tasks;
using ApplicationCore.DTOs;
using DomainCore.Repository;
using DomainCore.Logic.UserLogic;
using ApplicationServices.ManagemenUser;
using ApplicationCore.Contracts.UserContracts;
using DomainLogic.Logic.UserLogic;

namespace ApplicationServices.ManagementUser
{
    /// <summary>
    /// Servicio que orquesta las acciones para mantener un usuario.
    /// </summary>
    public class DeleteUserService : UserBaseService, IDeleteUserService
    {
   
        public DeleteUserService(IUnitOfWork uow, IUserRepository userRepository, IUserLogic getUserLogic) 
            : base(uow, userRepository, getUserLogic)
        {
        }

        public async Task DeleteUser(UserDto deleteUser)
        {
            var userAll =  _userRepository.GetAllWithTracking();
            _userLogic.ValidationsToDelete(userAll, deleteUser);
            var user = MapperUser.MapFromDtoToEntity(deleteUser);
            _userRepository.Delete(user);
            await _uow.CommitAsync();
        }
    }
}
