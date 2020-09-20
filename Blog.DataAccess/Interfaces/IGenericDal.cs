using Blog.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Interfaces
{
    public interface IGenericDal<T> where T : class, ITable, new()
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> keySelector);
        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> keySelector);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<T> FindByIdAsync(int id);

        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);

    }
}
