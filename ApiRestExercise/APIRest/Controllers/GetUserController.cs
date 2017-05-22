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
    public class GetUserController : ApiController
    {
        private readonly IGetUserService _getUserService;

        public GetUserController(
            IGetUserService getUserService)
        {

            _getUserService = getUserService;
        }
 

        // GET: api/User/5
        [ExceptionsHandler]
        [Route("{id}", Name = "GetById")]

        public async Task<IHttpActionResult> Get(int id)
        {
            UserDto user;
            user = await _getUserService.GetUserById(id);
            if (user == null)
                return NotFound();
            return Ok(user);


        }

    }
}
