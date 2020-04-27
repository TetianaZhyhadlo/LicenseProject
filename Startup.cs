using LicenseProject.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using LicenseProject.IServiceProviderFactory;
using LicenseProject.Service;



namespace LicenseProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(
#if DEBUG
                    Configuration.GetConnectionString("SQLConnectionString")
#else
                    Configuration.GetConnectionString("SQLConnectionString_Release")
#endif
                    )
            );

            services.AddTransient<IService<Soft>, SoftService>();

            //services.AddMvc(options => { options.AllowEmptyInputInBodyModelBinding = true; })
            //    .AddJsonOptions(options =>
            //    {
            //        //options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //        //options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    
            //    });
                
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [System.Obsolete]
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}

