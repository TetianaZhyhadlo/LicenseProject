using LicenseProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseProject.DB
{
    public class AsyncRepository<T> where T : class, IModel
    {
        private readonly Context dbContext;
        protected readonly DbSet<T> dbSet;

        public AsyncRepository(Context dbContext)
        {
            this.dbContext = dbContext;
            dbSet = this.dbContext.Set<T>();
        }

        public async Task CreateAsync(T item)
        {
            await dbSet.AddAsync(item);
            await dbContext.SaveChangesAsync();
        }

        public Task<T> FindByIdAsync(int id)
        {
            return dbSet.FindAsync(id);
        }

        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return dbSet.AsParallel().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public async Task RemoveAsync(T item)
        {
            dbSet.Remove(item);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T item)
        {
            dbSet.Update(item);
            await dbContext.SaveChangesAsync();
        }
    }
}
