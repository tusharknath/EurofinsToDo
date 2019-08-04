using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DataAccessLayer.Repository;

namespace ToDo.DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<User> UserRepository { get; }
        IRepository<Task> UserTasksRepository { get; }
        void Save();
    }
}
