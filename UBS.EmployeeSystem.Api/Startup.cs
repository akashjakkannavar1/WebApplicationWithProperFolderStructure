using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UBS.EmployeeSystem.Persistence;
using UBS.EmployeeSystem.Abstractions;
using UBS.EmployeeSystem.Api;
using UBS.EmployeeSystem;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace UBS.EmployeeSystem.Api
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
            services.AddTransient<IDatabaseSettings>(p => new DatabaseSettings
            {
                connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING"),
                dbName = Environment.GetEnvironmentVariable("DATABASE_NAME"),
                employeeCollectionName = nameof(Employee),
                adminCollectionName = nameof(Admin)
            });
            services.AddTransient<EmployeeService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Employee/Error");
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //app.UseCookiePolicy();
            app.UseMvc();
            //    (routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Employee}/{action=Index}/{id?}");
            //});
        }
    }
}
