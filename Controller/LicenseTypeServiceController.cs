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
        [Route("api/licensetype")]
        [ApiController]
        public class LicenseTypeServiceController : ControllerBase
        {
            readonly IService<LicenseType> service;

            public LicenseTypeServiceController(IService<LicenseType> service)
            {
                this.service = service;
            }

            [HttpGet]
            public List<LicenseType> Get()
            {
                return service
                    .GetQuery()
                    .ToList();
            }

            [HttpGet("{id}")]
            public LicenseType Get(int id)
            {
                return service.FindById(id);
            }

            [HttpPost("save")]
            public List<LicenseType> Post([FromBody] LicenseType value)
            {
                service.Create(value);
                return service
                    .GetAll()
                    .Where(x=>x.Type.Length!=0)
                    .ToList();
            }

            [HttpPut]
            public void Put(LicenseType value)
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
