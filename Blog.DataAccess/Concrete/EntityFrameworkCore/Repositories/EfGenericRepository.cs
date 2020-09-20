using Blog.DataAccess.Concrete.EntityFrameworkCore.Context;
using Blog.DataAccess.Interfaces;
using Blog.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<T> : IGenericDal<T> where T : class, ITable, new()
    {
        public async Task AddAsync(T entity)
        {
            using var context = new BlogDbContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            using var context = new BlogDbContext();
            return await context.FindAsync<T>(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            using var context = new BlogDbContext();
            return await context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            using var context = new BlogDbContext();
            return await context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T,TKey>> keySelector)
        {
            using var context = new BlogDbContext();
            return await context.Set<T>().Where(filter).OrderByDescending(keySelector).ToListAsync();
        }

        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            using var context = new BlogDbContext();
            return await context.Set<T>().OrderByDescending(keySelector).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            using var context = new BlogDbContext();
            return await context.Set<T>().FirstOrDefaultAsync(filter);
        }

        public async Task RemoveAsync(T entity)
        {
            using var context = new BlogDbContext();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            using var context = new BlogDbContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
