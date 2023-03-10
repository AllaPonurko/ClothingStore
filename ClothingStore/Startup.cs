using ClothingStore.Chat;
using ClothingStore.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClothingStore.Auth;
using ClothingStore.Models;

namespace ClothingStore
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews();
            services.AddSignalR();
            services.AddAuthorization();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // ?????????, ????? ?? ?????????????? ???????? ??? ????????? ??????
            ValidateIssuer = true,
            // ??????, ?????????????? ????????
            ValidIssuer = AuthOptions.ISSUER,
            // ????? ?? ?????????????? ??????????? ??????
            ValidateAudience = true,
            // ????????? ??????????? ??????
            ValidAudience = AuthOptions.AUDIENCE,
            // ????? ?? ?????????????? ????? ?????????????
            ValidateLifetime = true,
            // ????????? ????? ????????????
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            // ????????? ????? ????????????
            ValidateIssuerSigningKey = true,
        };
    });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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
                endpoints.MapRazorPages();
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chat");

            });
            //app.Map("/login/{username}", (username) =>
            //    {
            //        var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
            //        //??????? JWT-?????
            //        var jwt = new JwtSecurityToken(
            //                issuer: AuthOptions.ISSUER,
            //                audience: AuthOptions.AUDIENCE,
            //                claims: claims,
            //                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            //                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
            //                SecurityAlgorithms.HmacSha256));

            //        return new JwtSecurityTokenHandler().WriteToken(jwt);


            //    });

            //app.Map("/data", [Authorize] () => new { message = "Hello World!" });

        }
    }
}
