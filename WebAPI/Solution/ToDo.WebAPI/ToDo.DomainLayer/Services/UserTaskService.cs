using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DomainLayer.Services.Interface;
using ToDo.WebAPI.EF.Data.Model;
using ToDo.WebAPI.Repository.UnitOfWork;

namespace ToDo.DomainLayer.Services
{
    public class UserTaskService : IUserTaskService
    {
        private readonly IUnitOfWork _UoW;
        public UserTaskService(IUnitOfWork UoW)
        {
            _UoW = UoW;
        }

        public async Task<UserTask> CreateUserTask(UserTask userTask)
        {
            return await Task.Run(() => _UoW.Repository<UserTask>().Insert(userTask));
        }

        public async Task<UserTask> UpdateUserTask(UserTask userTask)
        {
            return await Task.Run(() => _UoW.Repository<UserTask>().Update(userTask));
        }

        public async Task<IEnumerable<UserTask>> GetAll(int userID)
        {
            return await Task.Run(() => _UoW.Repository<UserTask>().Get().Where(x => x.User_ID == userID).ToList());
        }

        public Task DeleteUserTask(int id)
        {
            return Task.Run(() => _UoW.Repository<UserTask>().Delete(id));
        }

        public async Task<UserTask> GetUserTaskByID(int id)
        {
            return await Task.Run(() => _UoW.Repository<UserTask>().GetById(id));
        }
    }
}
