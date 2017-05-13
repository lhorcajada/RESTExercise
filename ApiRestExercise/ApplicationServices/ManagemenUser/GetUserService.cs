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

namespace ApplicationServices.ManagementUser
{
    /// <summary>
    /// Servicio que orquesta las acciones para mantener un usuario.
    /// </summary>
    public class GetUserService : UserBaseService, IGetUserService
    {
   
        public GetUserService(IUnitOfWork uow, IUserRepository userRepository, IUserLogic getUserLogic) 
            : base(uow, userRepository, getUserLogic)
        {
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
