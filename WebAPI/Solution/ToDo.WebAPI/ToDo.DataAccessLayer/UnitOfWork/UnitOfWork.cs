using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DataAccessLayer.Repository;

namespace ToDo.DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, System.IDisposable
    {
        private readonly EuroFinsToDoEntities _context;
        private IRepository<User> _userRepository;
        private IRepository<Task> _userTasksRepository;

        public UnitOfWork(EuroFinsToDoEntities context)
        {
            _context = context;
        }

        public IRepository<User> UserRepository
        {
            get { return _userRepository ?? (_userRepository = new Repository<User>(_context)); }
        }

        public IRepository<Task> UserTasksRepository
        {
            get { return _userTasksRepository ?? (_userTasksRepository = new Repository<Task>(_context)); }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
    }
}
