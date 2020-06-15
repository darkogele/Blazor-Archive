using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ArchiveData.Interface
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
        void AddRange(ICollection<T> collection);
        void Update(T entity);
        void Delete(T entity);
        Task<T> GetById(Guid id);
        Task<ICollection<T>> GetAll();
        Task<bool> SaveAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> AsQueryable();
    }
}
