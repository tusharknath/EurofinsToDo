using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebAPI.EF.Data.Model;

namespace ToDo.WebAPI.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ToDoDBContext _context;
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        private DbContextTransaction _transaction;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        public UnitOfWork()
        {
            this._context = new ToDoDBContext();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IRepository<T>;
            }
            IRepository<T> repo = new Repository<T>(_context);
            repositories.Add(typeof(T), repo);
            return repo;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DbContextTransaction BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
            return _transaction;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Int64 SaveChanges()
        {
            return _context.SaveChanges();
        }
        /// <summary>
        /// IDisposable implementation
        /// </summary>
        private bool disposed = false;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
