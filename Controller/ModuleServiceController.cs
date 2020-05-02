using LicenseProject.Models;
using LicenseProject.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace LicenseProject.Controller
{
    [Route("api/module")]
    [ApiController]
    public class ModuleServiceController : ControllerBase
    {
        readonly IService<Module> service;

        public ModuleServiceController(IService<Module> service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<Module> Get()
        {
            return service
                .GetQuery()
                .Where(x => x.Name.Length > 0)
                .ToList();
        }
        [HttpGet("{include}")]
        public List<Module> GetComplexData()
        {
            return service
                .GetQuery()
                .Include(x => x.Soft)
                .ThenInclude(y => y.DeveloperTeam)
                .ThenInclude(x => x.PeopleQuantity)
                .ToList();      
        }

        [HttpGet("{id}")]
        public Module Get(int id)
        {
            return service.FindById(id);
        }

        [HttpPost("save")]
        public List<Module> Post([FromBody] Module value)
        {
            service.Create(value);
            return service
                .GetAll()
                .Where(x => x.SoftID > 0)
                .ToList();
        }

        [HttpPut]
        public void Put(Module value)
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
