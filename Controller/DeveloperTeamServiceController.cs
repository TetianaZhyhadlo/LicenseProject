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
        [Route("api/developerteam")]
        [ApiController]
        public class DeveloperTeamServiceController : ControllerBase
        {
            readonly IService<DeveloperTeam> service;

            public DeveloperTeamServiceController(IService<DeveloperTeam> service)
            {
                this.service = service;
            }

            [HttpGet]
            public List<DeveloperTeam> Get()
            {
                return service
                    .GetQuery()
                    .Include(x => x.Name)
                    .Include(x=>x.PeopleQuantity)
                    .ToList();
            }

            [HttpGet("{id}")]
            public DeveloperTeam Get(int id)
            {
                return service.FindById(id);
            }

            [HttpPost("save")]
            public List<DeveloperTeam> Post([FromBody] DeveloperTeam value)
            {
                service.Create(value);
                return service
                    .GetAll()
                    .Where(x=>x.Name!=null)
                    .ToList();
            }

            [HttpPut]
            public void Put(DeveloperTeam value)
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
