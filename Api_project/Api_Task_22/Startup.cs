using Api_Task_22.AuthPersonApp;
using Api_Task_22.Model;
using Api_Task_22.Model.DBC;
using Api_Task_22.Model.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Api_Task_22
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
                options.LoginPath = "/EnterLogin";
                options.LogoutPath = "/Logout";
                options.SlidingExpiration = true;
            });

            services.AddControllers();




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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
            CreateRoles(serviceProvider);

        }

    }
}
