using System.Threading.Tasks;
using ApplicationCore.DTOs;
using DomainCore.Repository;
using DomainCore.Logic.UserLogic;
using ApplicationCore.Contracts.UserContracts;
using System;
using CrossCutting.Resources;

namespace ApplicationServices.ManagementUser
{
    /// <summary>
    /// Servicio que orquesta las acciones para mantener un usuario.
    /// </summary>
    public class UpdateUserService : IUpdateUserService
    {

        private readonly IUnitOfWork _uow;
        private readonly IUserRepository _userRepository;
        private readonly IUpdateUserLogic _userLogic;
        public UpdateUserService(
            IUnitOfWork uow,
            IUserRepository userRepository,
            IUpdateUserLogic userLogic
            )
        {
            if (uow == null || userRepository == null || userLogic == null)
                throw new ArgumentNullException(Resource.ExceptionNullObject);
            _uow = uow;
            _userRepository = userRepository;
            _userLogic = userLogic;
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
