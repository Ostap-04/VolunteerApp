using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using Volunteer.DataAccess.Data.Services;

namespace VolunteerApp
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
            services.AddDbContext<VolunteerContext>(options => options.UseSqlServer(Configuration.GetConnectionString("VolunteerDbConnectionString")));

            services.AddControllersWithViews();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
