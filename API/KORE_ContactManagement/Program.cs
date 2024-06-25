using KORE_ContactManagement.Infrastructure.Configuration;
using KORE_ContactManagement.Application;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace KORE_ContactManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var  AllowSpecificOrigins = "_AllowSpecificOrigins";

            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(AllowSpecificOrigins,
                        builder =>
                        {
                            builder.WithOrigins(["http://localhost:4200","https://localhost:4200"])
                                   .AllowAnyHeader()
                                   .AllowAnyMethod()
                                   .AllowCredentials();
                        });
            });
            // Add services to the container.


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(); 

            builder.Services.AddApplication();
            builder.Services.AddRepositories(builder.Configuration);
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Startup>());
            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            
            app.UseCors(AllowSpecificOrigins);
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
