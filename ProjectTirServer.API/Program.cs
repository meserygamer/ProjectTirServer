using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProjectTirServer.API.Extensions;
using ProjectTirServer.DataBase;
using System.Security.Claims;

namespace ProjectTirServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Title = "Project Tir API",
                    Description = ""
                });
            });

            builder.Services.AddApiAuthentication();

            builder.Services.AddDbContext<ProjectTirDbContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString(nameof(ProjectTirDbContext)));
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(policy => policy.AllowAnyOrigin());

            app.UseHttpsRedirection();

            app.UseCookiePolicy(new CookiePolicyOptions 
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
                HttpOnly = HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.Always
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.AddMappedEndPoints();

            app.Run();
        }
    }
}
