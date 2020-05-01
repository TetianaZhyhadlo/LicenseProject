using LicenseProject.Models;
using LicenseProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;


namespace LicenseProject
{
    public class SellingService:IService<Selling>
    {
 
        public Repository<Selling> RepositoryDB { get; set; }

        public SellingService(Context dbContext)
        {
            RepositoryDB = new Repository<Selling>(dbContext);
        }

        public void Create(Selling item)
        {
            RepositoryDB.Create(item);
        }

        public void Delete(Selling item)
        {
            RepositoryDB.Remove(item);
        }

        public List<Selling> GetAll()
        {
            return RepositoryDB.GetAll().ToList();
        }

        public Selling Update(int id, Selling updatedItem)
        {
            RepositoryDB.Update(updatedItem);
            return updatedItem;
        }

        public Selling FindById(int id)
        {
            return RepositoryDB.FindById(id);
        }

        public IQueryable<Selling> GetQuery()
        {
            return RepositoryDB.GetAll();
        }

       
    }
}