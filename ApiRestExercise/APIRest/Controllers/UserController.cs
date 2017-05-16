using APIRest.Exceptions;
using ApplicationCore.Contracts.UserContracts;
using ApplicationCore.DTOs;
using CrossCutting.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace APIRest.Controllers
{
    [RoutePrefix("api/user")]
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
        public async Task<IHttpActionResult> Get()
        {
            var userAll = await _getUserService.GetUserAll();
            return Ok(userAll);
        }

        // GET: api/User/5
        [ExceptionsHandler]
        [Route("{id}", Name = "GetById")]

        public async Task<IHttpActionResult> Get(int id)
        {
            UserDto user;
            user = await _getUserService.GetUserById(id);
            return Ok(user);


        }

        // POST: api/User
        [ExceptionsHandler]
        [Route("")]
        public async Task<IHttpActionResult> Post([FromBody]UserDto user)
        {
            await _addUserService.AddUser(user);
            var userAll = await _getUserService.GetUserAll();
            var lastUser = userAll.OrderBy(u=> u.Id).Last();
            return CreatedAtRoute("GetById", new { id = lastUser.Id }, lastUser);
        }

        // PUT: api/User/5
        [ExceptionsHandler]
        [Route("{id}")]
        public async Task<IHttpActionResult> Put(int id, [FromBody]UserDto user)
        {
            await _updateUserService.UpdateUser(user);
            var userAll = await _getUserService.GetUserAll();
            var lastUser = userAll.OrderBy(u => u.Id).Last();
            return Ok(user);
        }

        // DELETE: api/User/5
        [ExceptionsHandler]
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await _deleteUserService.DeleteUser(id);
            return Ok(id);
        }
    }
}
