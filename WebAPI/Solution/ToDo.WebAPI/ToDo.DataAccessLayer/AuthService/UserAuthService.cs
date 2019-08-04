using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DataAccessLayer.DBModel;
using ToDo.DataAccessLayer.Repository;
using ToDo.DataAccessLayer.UnitOfWork;

namespace ToDo.DataAccessLayer.AuthService
{
    public class UserAuthService
    {
        private ToDoContext _context;
        public UserAuthService()
        {
            this._context = new ToDoContext();
        }

        public bool ValidateUser(string userName, string Password)
        {
            var result = _context.Users.SingleOrDefault(x => x.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase) && x.Password == Password);

            return result != null ? true : false;
        }
    }
}
