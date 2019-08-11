using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebAPI.EF.Data.Model;

namespace ToDo.DomainLayer.Services.Interface
{
    public interface ILoggerService
    {
        void Insert(Log log);
    }

}
