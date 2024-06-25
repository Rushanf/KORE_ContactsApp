using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KORE_ContactManagement.Application.Interfaces;
using KORE_ContactManagement.Infrastructure.Repositories.DummyRepo;
using KORE_ContactManagement.Domain.Entities;
using KORE_ContactManagement.Infrastructure.Repositories;

namespace KORE_ContactManagement.Infrastructure.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlServer"),
                     sqlServerOptions => sqlServerOptions.EnableRetryOnFailure(
                            maxRetryCount: 5, // Adjust as needed
                            maxRetryDelay: TimeSpan.FromSeconds(30), // Adjust as needed
                            errorNumbersToAdd: null));

            }, ServiceLifetime.Transient);


            services.AddScoped<IDbQueryRepository<Contact>, ContactReadDummyRepository>();
            services.AddScoped<IDbCommandRepository<Contact>, ContactWriteDummyRepository>();

            //services.AddScoped<IDbQueryRepository<Contact>, ContactReadRepository>();
            //services.AddScoped<IDbCommandRepository<Contact>, ContactWriteRepository>();


            return services;
        }
    }
}
