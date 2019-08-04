using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ToDo.WebAPI.Controllers
{
    public class UserTaskController : ApiController
    {
        // GET: api/UserTask
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
