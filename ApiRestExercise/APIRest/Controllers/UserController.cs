using APIRest.Exceptions;
using ApplicationCore.Contracts.UserContracts;
using ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace APIRest.Controllers
{
    public class UserController : ApiController
    {
        private readonly IAddUserService _addUserService;
        private readonly IUpdateUserService _updateUserService;
        private readonly IDeleteUserService _deleteUserService;
        private readonly IGetUserService _getUserService;
        
        public UserController(
            IAddUserService addUserService,
            IUpdateUserService updateUserService,
            IDeleteUserService deleteUserService,
            IGetUserService getUserService)
        {

            _addUserService = addUserService;
            _updateUserService = updateUserService;
            _deleteUserService = deleteUserService;
            _getUserService = getUserService;
        }
        // GET: api/User
        public async Task<IEnumerable<UserDto>> Get()
        {
            return await _getUserService.GetUserAll();
        }

        // GET: api/User/5
        [ExceptionsHandler]
        public async Task<UserDto> Get(int id)
        {
            return await _getUserService.GetUserById(id);
        }

        // POST: api/User
        [ExceptionsHandler]
        public async Task Post([FromBody]UserDto user)
        {
            await _addUserService.AddUser(user);
        }

        // PUT: api/User/5
        [ExceptionsHandler]
        public async Task Put(int id, [FromBody]UserDto user)
        {
            await _updateUserService.UpdateUser(user);
        }

        // DELETE: api/User/5
        [ExceptionsHandler]
        public async Task Delete([FromBody]UserDto user)
        {
            await _deleteUserService.DeleteUser(user);
        }
    }
}
