using LicenseProject.Models;
using LicenseProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;


namespace LicenseProject
{
    public class DeveloperTeamService:IService<DeveloperTeam>
    {
 
        public Repository<DeveloperTeam> RepositoryDB { get; set; }

        public DeveloperTeamService(Context dbContext)
        {
            RepositoryDB = new Repository<DeveloperTeam>(dbContext);
        }

        public void Create(DeveloperTeam item)
        {
            RepositoryDB.Create(item);
        }

        public void Delete(DeveloperTeam item)
        {
            RepositoryDB.Remove(item);
        }

        public List<DeveloperTeam> GetAll()
        {
            return RepositoryDB.GetAll().ToList();
        }

        public DeveloperTeam Update(int id, DeveloperTeam updatedItem)
        {
            RepositoryDB.Update(updatedItem);
            return updatedItem;
        }

        public DeveloperTeam FindById(int id)
        {
            return RepositoryDB.FindById(id);
        }

        public IQueryable<DeveloperTeam> GetQuery()
        {
            return RepositoryDB.GetAll();
        }

       
    }
}