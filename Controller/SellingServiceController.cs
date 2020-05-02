using LicenseProject.Models;
using LicenseProject.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace LicenseProject.Controller
{

        [Route("api/selling")]
        [ApiController]
        public class SellingServiceController : ControllerBase
        {
            readonly IService<Selling> service;

            public SellingServiceController(IService<Selling> service)
            {
                this.service = service;
            }

            [HttpGet]
            public List<Selling> Get()
            {
                return service
                    .GetQuery()
                    .Where(x=>x.Price>100)
                    .ToList();
            }

           
            [HttpGet("{id}")]
            public Selling Get(int id)
            {
                return service.FindById(id);
            }
            [HttpGet("{softSellingByID}")]
            public List<Selling> GetBySoft(int id)
            {
                return service
                    .GetQuery()
                    .Where(x => x.SoftID == id)
                    .ToList();
            }

            [HttpPost("save")]
            public List<Selling> Post([FromBody] Selling value)
            {
                service.Create(value);
                return service
                    .GetAll()
                    .Where(x=>x.Customer!=null)
                    .ToList();
            }

            [HttpPut]
            public void Put(Selling value)
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
