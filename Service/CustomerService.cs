using LicenseProject.Models;
using LicenseProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;


namespace LicenseProject
{
    public class CustomerService:IService<Customer>
    {
 
        public Repository<Customer> RepositoryDB { get; set; }

        public CustomerService(Context dbContext)
        {
            RepositoryDB = new Repository<Customer>(dbContext);
        }

        public void Create(Customer item)
        {
            RepositoryDB.Create(item);
        }

        public void Delete(Customer item)
        {
            RepositoryDB.Remove(item);
        }

        public List<Customer> GetAll()
        {
            return RepositoryDB.GetAll().ToList();
        }

        public Customer Update(int id, Customer updatedItem)
        {
            RepositoryDB.Update(updatedItem);
            return updatedItem;
        }

        public Customer FindById(int id)
        {
            return RepositoryDB.FindById(id);
        }

        public IQueryable<Customer> GetQuery()
        {
            return RepositoryDB.GetAll();
        }

       
    }
}