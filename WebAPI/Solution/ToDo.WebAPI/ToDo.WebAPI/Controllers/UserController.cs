using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ToDo.DataAccessLayer.DBModel;
using ToDo.DomainLayer.DomainServices;
using ToDo.WebAPI.Authentication;
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
            return _userService.GetAll();
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
