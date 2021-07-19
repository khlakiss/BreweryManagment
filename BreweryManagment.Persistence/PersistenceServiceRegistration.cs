using BreweryManagment.Application.Persistence;
using BreweryManagment.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BreweryManagment.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var migrationsAssembly = typeof(PersistenceServiceRegistration).GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContext<BreweryDBContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"], sql =>
                {
                    sql.MigrationsAssembly(migrationsAssembly);
                });
            }, ServiceLifetime.Transient);
            
            services.AddScoped<IWholesalerRepository, WholesalerRepository>();
            services.AddScoped<IBeerRepository, BeerRepository>();
            return services;
        }
    }
}
