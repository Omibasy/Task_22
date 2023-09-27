using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Task_22.Model;
using Task_22.Model.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Task_22.Model.DBContext;
using Task_22.AuthPersonApp;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace Task_22
{
    public class Startup
    {
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;  
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DbPhoneBook>(options =>
            {
                options.UseSqlServer(
                    Configuration.GetConnectionString("DbConnection"));
            });


   
            services.AddTransient<IPhoneBook, PhoneBook>();
            services.AddMvc(TuningMvc);

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<DbPhoneBook>()
                .AddDefaultTokenProviders();

           

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 7;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.SlidingExpiration = true;
            });

            
        }

        private void CreateRoles(IServiceProvider serviceProvider)
        {
          

            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            Task<IdentityResult> roleResult;

            Task<bool> hasAdminRole = roleManager.RoleExistsAsync("admin");
            hasAdminRole.Wait();

            if (!hasAdminRole.Result)
            {
                roleResult = roleManager.CreateAsync(new IdentityRole("admin"));
                roleResult.Wait();
            }

            Task<bool> hasUserRole = roleManager.RoleExistsAsync("user");
            hasAdminRole.Wait();

            if (!hasUserRole.Result)
            {
                roleResult = roleManager.CreateAsync(new IdentityRole("user"));
                roleResult.Wait();
            }

        }

        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            app.UseStaticFiles();


            app.UseAuthentication();

            app.UseMvc(GetRoute);

            CreateRoles(serviceProvider);

        }

        private void GetRoute(IRouteBuilder route)
        {
            route.MapRoute("home", "{controller=home}/{action=Index}");
        }

        private void TuningMvc(MvcOptions switches)
        {
            switches.EnableEndpointRouting = false;
        }
    }
}
