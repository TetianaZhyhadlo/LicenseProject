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
                .ToList();
        }

        [HttpGet("{id}")]
        public DeveloperTeam Get(int id)
        {
            return service.FindById(id);
        }

        [HttpPost("save by ID")]
        public void Post(int id, DeveloperTeam value)
        {
            if (value != null)
            {
                if (value.ID == id)
                {
                    DeveloperTeam updatedItem = service.FindById(id);
                    updatedItem.Name = value.Name;
                    updatedItem.PeopleQuantity = value.PeopleQuantity;
                    service.Update(id, updatedItem);
                }

            }
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
