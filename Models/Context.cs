using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LicenseProject.Models;

namespace LicenseProject.Models
{
    public class Context: DbContext
    {
        public DbSet<Soft> Softs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DeveloperTeam> DeveloperTeams { get; set; }
        public Context(DbContextOptions<Context> options): base(options)
        {

        }
        


    }
}
