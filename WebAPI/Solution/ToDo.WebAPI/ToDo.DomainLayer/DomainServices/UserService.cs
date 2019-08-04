using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DataAccessLayer.DBModel;
using ToDo.DataAccessLayer.Repository;
using ToDo.DataAccessLayer.UnitOfWork;
using ToDo.DomainLayer.EntityService;

namespace ToDo.DomainLayer.DomainServices
{
    public class UserService : EntityService<User> , IUserService
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
