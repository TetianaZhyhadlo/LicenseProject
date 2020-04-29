using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LicenseProject.Models
{
    public class Repository<T> where T: class, IModel
    {
        private readonly Context dbContext;
        protected readonly DbSet<T> dbSet;

        public Repository(Context dbContext)
        {
            this.dbContext = dbContext;
            dbSet = this.dbContext.Set<T>();
        }

        public void Create(T item)
        {
            dbSet.Add(item);
            dbContext.SaveChanges();
        }

        public T FindById(int id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public void Remove(T item)
        {
            dbSet.Remove(item);
            dbContext.SaveChanges();
        }

        public void Update(T item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }
    }
}
