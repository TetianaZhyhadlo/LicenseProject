using LicenseProject.Models;
using LicenseProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;


namespace LicenseProject
{
    public class DiscountService:IService<Discount>
    {
 
        public Repository<Discount> RepositoryDB { get; set; }

        public DiscountService(Context dbContext)
        {
            RepositoryDB = new Repository<Discount>(dbContext);
        }

        public void Create(Discount item)
        {
            RepositoryDB.Create(item);
        }

        public void Delete(Discount item)
        {
            RepositoryDB.Remove(item);
        }

        public List<Discount> GetAll()
        {
            return RepositoryDB.GetAll().ToList();
        }

        public Discount Update(int id, Discount updatedItem)
        {
            RepositoryDB.Update(updatedItem);
            return updatedItem;
        }

        public Discount FindById(int id)
        {
            return RepositoryDB.FindById(id);
        }

        public IQueryable<Discount> GetQuery()
        {
            return RepositoryDB.GetAll();
        }

       
    }
}