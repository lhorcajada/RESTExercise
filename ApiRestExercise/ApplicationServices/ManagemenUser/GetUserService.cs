using System.Threading.Tasks;
using ApplicationCore.DTOs;
using DomainCore.Repository;
using DomainCore.Logic.UserLogic;
using ApplicationServices.ManagemenUser;
using ApplicationCore.Contracts.UserContracts;
using System.Linq;
using System.Data.Entity;
using DomainLogic.Logic.UserLogic;
using System;
using System.Collections.Generic;
using CrossCutting.Resources;

namespace ApplicationServices.ManagementUser
{
    /// <summary>
    /// Servicio que orquesta las acciones para mantener un usuario.
    /// </summary>
    public class GetUserService : IGetUserService
    {

        private readonly IUnitOfWork _uow;
        private readonly IUserRepository _userRepository;
        private readonly IGetUserLogic _userLogic;
        public GetUserService(
            IUnitOfWork uow,
            IUserRepository userRepository,
            IGetUserLogic userLogic
            )
        {
            if (uow == null || userRepository == null || userLogic == null)
                throw new ArgumentNullException(Resource.ExceptionNullObject);
            _uow = uow;
            _userRepository = userRepository;
            _userLogic = userLogic;
        }


        public async Task<IEnumerable<UserDto>> GetUserAll()
        {
            var userAll = await _userRepository.GetAll().ToListAsync();
            return MapperUser.MapFromEntityListToDtoList(userAll);
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var userAll =  _userRepository.GetAllWithTracking();
            var userFinded = await _userLogic.QueryToGetUserById(userAll, id).FirstOrDefaultAsync();
            _userLogic.ValidationsToGetById(userFinded);
            return MapperUser.MapFromEntityToDto(userFinded);
        }
      
    }
}
