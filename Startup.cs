using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using LicenseProject.Models;
using LicenseProject.Service;
using LicenseProject.IServiceProviderFactory;

namespace LicenseProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("SQLConnectionString")
                    )
            );

            services.AddTransient<IService<Customer>, CustomerService>();
            services.AddTransient<IService<DeveloperTeam>, DeveloperTeamService>();
            services.AddTransient<IService<Discount>, DiscountService>();
            services.AddTransient<IService<LicenseType>, LicenseTypeService>();
            services.AddTransient<IService<Module>, ModuleService>();
            services.AddTransient<IService<Selling>, SellingService>();
            services.AddTransient<IService<Soft>, SoftService>();

            services.AddMvc(options => { options.AllowEmptyInputInBodyModelBinding = true; })
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}

