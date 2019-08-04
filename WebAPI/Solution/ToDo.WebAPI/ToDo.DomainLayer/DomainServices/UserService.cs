using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DataAccessLayer.Repository;
using ToDo.DataAccessLayer.UnitOfWork;
using ToDo.DomainLayer.EntityService;
using ToDo.WebAPI.Common.DataBaseModel;

namespace ToDo.DomainLayer.DomainServices
{
    public class UserService : EntityService<User>
    {
        IUnitOfWork _unitOfWork;
        IRepository<User> _usersRepository;

        public UserService(IUnitOfWork unitOfWork,
                           IRepository<User> usersRepository)
            : base(unitOfWork, usersRepository)
        {
            this._unitOfWork = unitOfWork;
            this._usersRepository = usersRepository;
        }

        
    }
}
