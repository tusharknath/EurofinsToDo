using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DataAccessLayer.Repository;
using ToDo.DataAccessLayer.UnitOfWork;
using ToDo.DomainLayer.EntityService;

namespace ToDo.DomainLayer.DomainServices
{
    public class UserTaskService : EntityService<Task>
    {
        IUnitOfWork _unitOfWork;
        IRepository<Task> _userTasksRepository;

        public UserTaskService(IUnitOfWork unitOfWork,
                           IRepository<Task> userTasksRepository)
            : base(unitOfWork, userTasksRepository)
        {
            this._unitOfWork = unitOfWork;
            this._userTasksRepository = userTasksRepository;
        }


    }
}
