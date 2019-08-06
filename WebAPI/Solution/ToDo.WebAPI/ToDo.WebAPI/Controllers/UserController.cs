using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using ToDo.DomainLayer.Services;
using ToDo.WebAPI.Authentication;
using ToDo.WebAPI.EF.Data.Model;
using ToDo.WebAPI.Helper;

namespace ToDo.WebAPI.Controllers
{
    //[BasicAuthentication]
    public class UserController : ApiController
    {        

        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }



        [AllowAnonymous]
        [HttpPost]
        public async Task<IHttpActionResult> Authenticate([FromBody]User userParam)
        {
            var user = await _userService.Authenticate(userParam.UserName, userParam.Password);

            if (user == null)
                return BadRequest();

            return Ok(user);
        }
    }
}
