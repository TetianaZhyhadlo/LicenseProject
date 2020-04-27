using LicenseProject.Models;
using LicenseProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseProject.IServiceProviderFactory
{
    public class SoftService:IService<Soft>
    {

        public Repository<Soft> RepositoryDB { get; set; }

        public SoftService(Context dbContext)
        {
            RepositoryDB = new Repository<Soft>(dbContext);
        }

        public void Create(Soft item)
        {
            RepositoryDB.Create(item);
        }

        public void Delete(Soft item)
        {
            RepositoryDB.Remove(item);
        }

        public List<Soft> GetAll()
        {
            return RepositoryDB.GetAll().ToList();
        }

        public Soft Update(int id, Soft updatedItem)
        {
            RepositoryDB.Update(updatedItem);
            return updatedItem;
        }

        public Soft FindById(int id)
        {
            return RepositoryDB.FindById(id);
        }

        public IQueryable<Soft> GetQuery()
        {
            return RepositoryDB.GetAll();
        }
    }
}
