using ArchiveData.CustomRepos.Contracts;
using ArchiveData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveData.CustomRepos
{
    public class Users : IUsers
    {
        public Users()
        {

        }
        public Task Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(ICollection<User> collection)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> FindByCondition(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAll()
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
