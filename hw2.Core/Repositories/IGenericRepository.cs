using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace hw2.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {

        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();

        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);

    }
}
