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
        [Route("api/discount")]
        [ApiController]
        public class DiscountServiceController : ControllerBase
        {
            readonly IService<Discount> service;

            public DiscountServiceController(IService<Discount> service)
            {
                this.service = service;
            }

            [HttpGet]
            public List<Discount> Get()
            {
                return service
                    .GetQuery()
                    .Include(x=>x.DiscountName)
                    .ToList();
            }

            [HttpGet("{id}")]
            public Discount Get(int id)
            {
                return service.FindById(id);
            }

            [HttpPost("save")]
            public List<Discount> Post([FromBody] Discount value)
            {
                service.Create(value);
                return service
                    .GetAll()
                    .Where(x => x.Percantage>=0)
                    .ToList();
            }

            [HttpPut]
            public void Put(Discount value)
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
