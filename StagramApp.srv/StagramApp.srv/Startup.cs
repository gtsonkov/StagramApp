using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using StagramApp.srv.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StagramApp.srv.Data.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace StagramApp.srv
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        //TODO: Refactoring 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StagramDbContext>(options =>
                options.UseSqlServer(
                    this.Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<StagramDbContext>();

            var applicationSettingsConfig = this.Configuration.GetSection("ApplicationSettings");
            services.Configure<ApplicationSettings>(applicationSettingsConfig);

            var appSettings = applicationSettingsConfig.Get<ApplicationSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.SecretString);

            services.AddAuthentication(a =>
            {
                a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(j =>
                {
                    j.RequireHttpsMetadata = false;
                    j.SaveToken = true;
                    j.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(x =>
            x.AllowAnyOrigin()
             .AllowAnyHeader()
             .AllowAnyMethod());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}