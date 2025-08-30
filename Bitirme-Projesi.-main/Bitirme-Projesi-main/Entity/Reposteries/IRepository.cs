using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Reposteries
{
    public interface IRepository<T>
    {
        Task CreateAsync(T entity);
        Task SaveChanges();
        Task DeleteAsync(T category);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetByIdAsync(int Id);
        Task UpdateAsync(T entity);
        Task DeleteByIdAsync(int Id);
        Task<T> GetOneAsync(Expression<Func<T, bool>> filter = null);
    }
}
