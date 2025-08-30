using DAL.Concrate.EfCore.Context;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EfCore
{
    public class Repository<T>
    where T : class
    {
        private readonly DataContext context;

        public Repository(DataContext datacontext)
        {
            context = datacontext;
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                return await context.Set<T>().Where(filter).ToListAsync();
            }

            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetOneAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                return await context.Set<T>().Where(filter).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task CreateAsync(T category)
        {
            await context.Set<T>().AddAsync(category);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }
        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            context.Update(entity);
        }

        public async Task DeleteByIdAsync(int Id)
        {
            var product = await context.Set<T>().FindAsync(Id);
            if (product != null)
            {
                context.Set<T>().Remove(product);
                await context.SaveChangesAsync();
            }
        }

    }
}
