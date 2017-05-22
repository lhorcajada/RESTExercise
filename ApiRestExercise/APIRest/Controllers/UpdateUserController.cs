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
    public class UpdateUserController : ApiController
    {
        private readonly IUpdateUserService _updateUserService;
        private readonly IGetUserService _getUserService;

        public UpdateUserController(
            IUpdateUserService updateUserService,
            IGetUserService getUserService)
        {

            _updateUserService = updateUserService;
            _getUserService = getUserService;
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
 
    }
}
