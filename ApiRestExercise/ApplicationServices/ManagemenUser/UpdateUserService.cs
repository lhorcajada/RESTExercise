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
    public class UpdateUserService : UserBaseService, IUpdateUserService
    {
   
        public UpdateUserService(IUnitOfWork uow, IUserRepository userRepository, IUserLogic updateUserLogic) 
            : base(uow, userRepository, updateUserLogic)
        {
        }

        public async Task UpdateUser(UserDto userDto)
        {
            var userAll =  _userRepository.GetAllWithTracking();
            _userLogic.ValidationsToUpdate(userAll, userDto);
            var user = MapperUser.MapFromDtoToEntity(userDto);
            _userRepository.Update(user);
            await _uow.CommitAsync();
        }
    }
}
