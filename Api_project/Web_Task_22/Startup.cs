using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Web_Task_22
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
          services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => 
                {
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logout";
                });

            services.AddAuthorization();

            services.AddMvc(TuningMvc);



        }



        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            app.UseStaticFiles();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMvc(GetRoute);



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
