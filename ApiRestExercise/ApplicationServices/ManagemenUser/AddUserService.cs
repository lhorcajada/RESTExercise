using ApplicationCore.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using DomainCore.Repository;
using Data;
using DomainCore.Logic.UserLogic;
using CrossCutting.Resources;
using ApplicationServices.ManagemenUser;
using ApplicationCore.Contracts.UserContracts;
using DomainLogic.Logic.UserLogic;

namespace ApplicationServices.ManagementUser
{
    /// <summary>
    /// Servicio que orquesta las acciones para mantener un usuario.
    /// </summary>
    public class AddUserService : IAddUserService
    {

        private readonly IUnitOfWork _uow;
        private readonly IUserRepository _userRepository;
        private readonly IAddUserLogic _userLogic;
        public AddUserService(
            IUnitOfWork uow,
            IUserRepository userRepository,
            IAddUserLogic userLogic
            )
        {
            if (uow == null || userRepository == null || userLogic == null)
                throw new ArgumentNullException(Resource.ExceptionNullObject);
            _uow = uow;
            _userRepository = userRepository;
            _userLogic = userLogic;
        }

        public async Task AddUser(UserDto userDto)
        {
            var userAll =  _userRepository.GetAll();
            _userLogic.ValidationsToAdd(userAll, userDto);
            var user = MapperUser.MapFromDtoToEntity(userDto);
            _userRepository.Add(user);
            await _uow.CommitAsync();
        }
    }
}
