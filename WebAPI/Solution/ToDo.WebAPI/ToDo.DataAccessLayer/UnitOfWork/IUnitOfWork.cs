using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DataAccessLayer.Repository;

namespace ToDo.DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}
