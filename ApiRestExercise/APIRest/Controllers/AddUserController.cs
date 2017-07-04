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
    public class AddUserController : ApiController
    {
        private readonly IAddUserService _addUserService;
        private readonly IGetUserService _getUserService;

        public AddUserController(
            IAddUserService addUserService,
            IGetUserService getUserService)
        {

            _addUserService = addUserService;
            _getUserService = getUserService;
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

   
    }
}
