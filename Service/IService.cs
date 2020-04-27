using LicenseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseProject.Service
{
    public interface IService<T> where T : class, IModel
    {
        Repository<T> RepositoryDB { get; set; }
        List<T> GetAll();
        T FindById(int id);
        void Create(T item);
        void Delete(T id);
        T Update(int id, T updatedItem);
        IQueryable<T> GetQuery();
    }
}
