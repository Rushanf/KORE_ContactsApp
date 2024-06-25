using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KORE_ContactManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) =>
            // register all Commands, Queries and Domain event handlers
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Startup>());
    }

}
