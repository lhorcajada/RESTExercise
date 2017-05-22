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
    public class DeleteUserController : ApiController
    {
        private readonly IAddUserService _addUserService;
        private readonly IUpdateUserService _updateUserService;
        private readonly IDeleteUserService _deleteUserService;
        private readonly IGetUserService _getUserService;

        public DeleteUserController(
            IDeleteUserService deleteUserService,
            IGetUserService getUserService)
        {

            _deleteUserService = deleteUserService;
            _getUserService = getUserService;
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
