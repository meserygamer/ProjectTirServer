using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProjectTirServer.API.EndPoints;
using ProjectTirServer.DataBase;

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

            app.AddMappedEndPoints();

            app.Run();
        }
    }
}
