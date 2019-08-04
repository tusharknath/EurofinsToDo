using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DataAccessLayer.DBModel;
using ToDo.DomainLayer.EntityService;

namespace ToDo.DomainLayer.DomainServices
{
    public interface IUserService : IEntityService<User>
    {
    }
}
