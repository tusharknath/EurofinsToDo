using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.WebAPI.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : class;
        DbContextTransaction BeginTransaction();
        Int64 SaveChanges();
    }
}
