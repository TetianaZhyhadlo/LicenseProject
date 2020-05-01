using LicenseProject.Models;
using LicenseProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;


namespace LicenseProject
{
    public class LicenseTypeService:IService<LicenseType>
    {
 
        public Repository<LicenseType> RepositoryDB { get; set; }

        public LicenseTypeService(Context dbContext)
        {
            RepositoryDB = new Repository<LicenseType>(dbContext);
        }

        public void Create(LicenseType item)
        {
            RepositoryDB.Create(item);
        }

        public void Delete(LicenseType item)
        {
            RepositoryDB.Remove(item);
        }

        public List<LicenseType> GetAll()
        {
            return RepositoryDB.GetAll().ToList();
        }

        public LicenseType Update(int id, LicenseType updatedItem)
        {
            RepositoryDB.Update(updatedItem);
            return updatedItem;
        }

        public LicenseType FindById(int id)
        {
            return RepositoryDB.FindById(id);
        }

        public IQueryable<LicenseType> GetQuery()
        {
            return RepositoryDB.GetAll();
        }

       
    }
}