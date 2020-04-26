using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LicenseProject.Models
{
    public class Context: DbContext
    {
        public DbSet<Soft> Softs { get; set; }
        //public DbSet<LoginHistory> Logins { get; set; }
        public Context(DbContextOptions<Context> options): base(options)
        {

        }


    }
}
