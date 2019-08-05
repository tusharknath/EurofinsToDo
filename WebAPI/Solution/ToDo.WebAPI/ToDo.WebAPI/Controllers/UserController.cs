using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ToDo.DomainLayer.Services;
using ToDo.WebAPI.Authentication;
using ToDo.WebAPI.EF.Data.Model;
using ToDo.WebAPI.Helper;

namespace ToDo.WebAPI.Controllers
{
    [BasicAuthentication]
    public class UserController : ApiController
    {        

        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/UserTask
        public IEnumerable<User> Get()
        {
            var user = Util.GetUsername();
            return _userService.Get();
        }

        // GET: api/UserTask/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserTask
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserTask/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserTask/5
        public void Delete(int id)
        {
        }
    }
}
