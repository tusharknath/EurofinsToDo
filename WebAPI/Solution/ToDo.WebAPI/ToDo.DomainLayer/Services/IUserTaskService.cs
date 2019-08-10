using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebAPI.EF.Data.Model;

namespace ToDo.DomainLayer.Services
{
    public interface IUserTaskService
    {
        Task<IEnumerable<UserTask>> GetAll(int userID);

        Task<UserTask> CreateUserTask(UserTask userTask);

        Task<UserTask> UpdateUserTask(UserTask userTask);

        Task DeleteUserTask(int id);

        Task<UserTask> GetUserTaskByID(int id);
    }
}
