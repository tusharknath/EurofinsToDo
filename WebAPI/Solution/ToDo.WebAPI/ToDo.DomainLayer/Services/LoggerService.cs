using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebAPI.EF.Data.Model;
using ToDo.WebAPI.Repository.UnitOfWork;

namespace ToDo.DomainLayer.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly IUnitOfWork _UoW;
        public LoggerService(IUnitOfWork UoW)
        {
            _UoW = UoW;
        }
        public void Insert(Log log)
        {
            _UoW.Repository<Log>().Insert(log);
            _UoW.SaveChanges();
        }
    }
}