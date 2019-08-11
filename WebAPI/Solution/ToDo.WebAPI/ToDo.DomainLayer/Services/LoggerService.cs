using System.Threading.Tasks;
using ToDo.DomainLayer.Services.Interface;
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
            Task.Run(() => _UoW.Repository<Log>().Insert(log));
        }
    }
}