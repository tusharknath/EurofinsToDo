using System.Collections.Generic;

namespace ToDo.DomainLayer.EntityService
{
    public interface IEntityService<T>
    {
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
}
