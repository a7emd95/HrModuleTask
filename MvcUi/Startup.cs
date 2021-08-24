using AppServices;
using Core.Interfaces.AppServices;
using Core.Interfaces.Base;
using Core.Models.Candidate;
using Core.Models.JobPosition;
using Core.Models.Question;
using Core.Models.QuestionAnswer;
using Core.Validitors;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Base;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
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
            services.AddTransient<IJobPostionService, JobPositionService>();
            services.AddTransient<ICandidateService, CandidateService>();
            services.AddTransient<IQuestionService, QuestionService>();


            //setUp Validitors
            services.AddTransient<IValidator<CreateJobPositionModel>, JobPositionValiditor>();
            services.AddTransient<IValidator<CreateQuestionModel>, QuestionValiditor>();
            services.AddTransient<IValidator<CreateCandidateModel>, CandidateValiditor>();
            services.AddTransient<IValidator<CreateQuestionAnswerModel>, QuestionAnswerValiditor>();

            //setUp AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //setUp Authantication 
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(
                options =>
                {
                    options.LoginPath = "/account/login";
                }
                );


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
