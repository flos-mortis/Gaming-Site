using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using TestStore.Services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace TestStore
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
            services.AddTransient<IPasswordValidator<User>, CustomPasswordValidator>
                (serv => new CustomPasswordValidator(6));
                
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(opts => opts.User.RequireUniqueEmail = true)
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();
            /*services.AddTransient<IGames, GameRepository>();
            services.AddTransient<IGenre, GenreRepository>();*/

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddGoogle(opts =>
                {
                    opts.ClientId = "376565521633-ovqjk2hotfb7e5jsm1mj5r0pu1brdd2q.apps.googleusercontent.com";
                    opts.ClientSecret = "i0p0c0dxOwSCUE5Q3HfvOtX9";
                    opts.SignInScheme = IdentityConstants.ExternalScheme;
                })
            .AddJwtBearer(options =>
             {
                 options.RequireHttpsMetadata = false;
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidIssuer = AuthOptions.ISSUER,
                     ValidateAudience = true,
                     ValidAudience = AuthOptions.AUDIENCE,
                     ValidateLifetime = true,
                     IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                     ValidateIssuerSigningKey = true,
                 };
                 options.Events = new JwtBearerEvents
                 {
                     OnMessageReceived = context =>
                     {
                         var accessToken = context.Request.Query["access_token"];

                         // если запрос направлен хабу
                         var path = context.HttpContext.Request.Path;
                         if (!string.IsNullOrEmpty(accessToken) &&
                             (path.StartsWithSegments("/chatter")))
                         {
                             // получаем токен из строки запроса
                             context.Token = accessToken;
                         }
                         return Task.CompletedTask;
                     }
                 };
             });
                 services.AddControllersWithViews();

            services.AddSignalR();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<ChatHub>("/chatter");
            });
        }
    }
}
