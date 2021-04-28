using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SomeAPIAPP.Data;
using SomeAPIAPP.Data.Contracts;
using SomeAPIAPP.Data.Repositories;
using Newtonsoft.Json.Serialization;

namespace SomeAPIAPP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Register Dependency here for using DI
        public void ConfigureServices(IServiceCollection services)
        {
            // register db
            services.AddDbContext<SomeAPIContext>(opt => opt.UseSqlServer
            (
                Configuration.GetConnectionString("SomeAPIAppConnection")
            ));
            //register the automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers().AddNewtonsoftJson(
                s=> {s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();}
            );
            // sample code to register (DI) the repository with its repo class
            //services.AddScoped<IRepo, MockRepo>();
            services.AddScoped<ISomeAPIAppRepo, SQLSomeAPIAppRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
