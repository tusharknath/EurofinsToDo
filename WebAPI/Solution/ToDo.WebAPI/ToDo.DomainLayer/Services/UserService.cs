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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="PasswordHash"></param>
        /// <returns></returns>
        public User ValidateUser(string Username, string PasswordHash)
        {
            return _UoW.Repository<User>().GetFirstOrDefault(x => x.UserName == Username && x.Password == PasswordHash);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> Get()
        {
            return _UoW.Repository<User>().Get().ToList();
        }
    }
}
