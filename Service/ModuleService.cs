using LicenseProject.Models;
using LicenseProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;


namespace LicenseProject
{
    public class ModuleService:IService<Module>
    {
 
        public Repository<Module> RepositoryDB { get; set; }

        public ModuleService(Context dbContext)
        {
            RepositoryDB = new Repository<Module>(dbContext);
        }

        public void Create(Module item)
        {
            RepositoryDB.Create(item);
        }

        public void Delete(Module item)
        {
            RepositoryDB.Remove(item);
        }

        public List<Module> GetAll()
        {
            return RepositoryDB.GetAll().ToList();
        }

        public Module Update(int id, Module updatedItem)
        {
            RepositoryDB.Update(updatedItem);
            return updatedItem;
        }

        public Module FindById(int id)
        {
            return RepositoryDB.FindById(id);
        }

        public IQueryable<Module> GetQuery()
        {
            return RepositoryDB.GetAll();
        }

       
    }
}