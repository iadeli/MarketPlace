using Market.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetByConditionAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAllQueryable();
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T entity);
    }
}
