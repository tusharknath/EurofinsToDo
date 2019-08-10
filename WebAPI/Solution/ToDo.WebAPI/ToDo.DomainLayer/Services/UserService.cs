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

            return user;
        }

        public async Task<User> Register(User userDTO)
        {
            // validation
            if (string.IsNullOrWhiteSpace(userDTO.Password))
                throw new AppException("Password is required.");

            var existingUser = _UoW.Repository<User>().GetFirstOrDefault(x => x.UserName.ToUpper() == userDTO.UserName.ToUpper());
            if(existingUser != null)
                throw new AppException("Username \"" + userDTO.UserName + "\" is already taken.");

            var user = await System.Threading.Tasks.Task.Run(() => _UoW.Repository<User>().Insert(userDTO));

            // return null if user not found
            if (user == null)
                throw new AppException("Invalid UserName or Password.");

            return user;
        }

        public string ForgotPassword(User userDTO)
        {
            // validation
            if (string.IsNullOrWhiteSpace(userDTO.UserName))
                throw new AppException("UserName is required.");

            var existingUser =  _UoW.Repository<User>().GetFirstOrDefault(x => x.UserName.ToUpper() == userDTO.UserName.ToUpper());
            if (existingUser != null)
                return existingUser.Password;
            else
                return null;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            // return users without passwords
            return await System.Threading.Tasks.Task.Run(() => _UoW.Repository<User>().Get());
        }

        public async Task<int> GetUserID(string userName)
        {
            return await System.Threading.Tasks.Task.Run(() => _UoW.Repository<User>().Get().Where(x => x.UserName.ToUpper() == userName.ToUpper()).Select(x => x.ID).SingleOrDefault());
        }
    }
}
