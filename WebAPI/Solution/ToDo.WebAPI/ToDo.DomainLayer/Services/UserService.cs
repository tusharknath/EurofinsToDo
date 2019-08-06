using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebAPI.EF.Data.Model;
using ToDo.WebAPI.Repository.UnitOfWork;

namespace ToDo.DomainLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _UoW;
        public UserService(IUnitOfWork UoW)
        {
            _UoW = UoW;
        }
        
        public async Task<User> Authenticate(string username, string password)
        {
            var user = await System.Threading.Tasks.Task.Run(() => _UoW.Repository<User>().GetFirstOrDefault(x => x.UserName == username && x.Password == password));

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so return user details without password
            user.Password = null;
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            // return users without passwords
            return await System.Threading.Tasks.Task.Run(() => _UoW.Repository<User>().Get());
        }
    }
}
