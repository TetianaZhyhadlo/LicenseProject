using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LicenseProject.Models;
using LicenseProject.Service;

namespace LicenseProject.Controller
{
    [Route("api/soft")]
    [ApiController]
    public class SoftServiceController : ControllerBase
    {
        
        readonly IService<Soft> service;

        public SoftServiceController(IService<Soft> service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<Soft> Get()
        {
            return service
                .GetQuery()
                .ToList();
        }

        [HttpGet("{include}")]
        public List<Soft> GetComplex()
        {
            return service
                .GetQuery()
                .Include(x => x.Name)
                .Include(x => x.DeveloperTeam)
                .ThenInclude(y => y.PeopleQuantity)
                .ToList();        
        }
      


        [HttpGet("{id}")]
        public Soft Get(int id) // поиск по ID
        {
            return service.FindById(id);
        }

        [HttpGet("{name}")]
        public List<Soft> Get(string name) // поиск по имени софта
        {
            return service
               .GetAll()
               .Where(x => x.Name == name)
               .ToList();
        }


        [HttpPost("save")]
        public List<Soft> Post([FromBody] Soft value)
        {
            return service
                .GetAll()
                .ToList();
        }

        [HttpPut]
        public void Put(Soft value)
        {
            service.Create(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(service.FindById(id));
        }

    }
}
