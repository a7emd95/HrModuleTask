using AppServices;
using Core.Interfaces.AppServices;
using Core.Interfaces.Base;
using Core.Models.JobPosition;
using Core.Validitors;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Base;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcUi
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
            services.AddDbContext<AppDbContext>(
                (options) => options.UseSqlServer(Configuration.GetConnectionString("cs"))
                );


            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            //setUp Business Services
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IJobPostionAppService, JobPositionAppService>();
            

            //setUp Validitors
            services.AddTransient<IValidator<CreateJobPositionModel>, JobPositionValiditor>();

            //setUp AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            services.AddControllersWithViews().AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
