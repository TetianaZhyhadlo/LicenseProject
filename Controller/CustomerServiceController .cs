using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LicenseProject.Models;
using LicenseProject.Service;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore.Internal;
using LicenseProject.DB;

namespace LicenseProject.Controller
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerServiceController : ControllerBase
    {
        
        readonly IService<Customer> service;

        public CustomerServiceController(IService<Customer> service)
        {
            this.service = service;
        }       

        [HttpGet]
        public List<Customer> Get()
        {
            return service
                .GetQuery()
                .ToList();

        }

        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return service.FindById(id);
        }

        [HttpGet("{name}")]
        public List<Customer> Get(string name) // поиск по имени
        {
           return service
                .GetQuery()
                .Where(x=>x.Name==name)
                .ToList();
        }

        [HttpPost("save")]
        public void Post(int id, Customer value)
        {
            if (value != null)
            {
                if (value.ID == id)
                {
                    Customer updatedItem = service.FindById(id);
                    updatedItem.Name = value.Name;
                    updatedItem.Adress = value.Adress;
                    service.Update(id, updatedItem);
                }
            }
        }

        [HttpPut]
        public void Put(Customer value)
        {
            service.Create(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(service.FindById(id));
        }
        [HttpDelete("async/{id}")]
         public async Task DeleteAsync(Customer value)
        {
            await DeleteAsync(value);
        }
        [HttpPut("{async}")]
        public async Task CreateAsync(Customer value)
        {
            await CreateAsync(value);
        }




    }
}
