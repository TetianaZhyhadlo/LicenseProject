using Microsoft.EntityFrameworkCore;

namespace LicenseProject.Models
{
    public class Context: DbContext
    {
        public DbSet<Soft> Softs { get; set; }
        public DbSet<Module>Moduls { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DeveloperTeam> DeveloperTeams { get; set; }
        public DbSet<Selling> Sellings { get; set; }
        public DbSet<LicenseType> LicenseTypes { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public Context(DbContextOptions<Context> options): base(options)
        {

        }
        


    }
}
