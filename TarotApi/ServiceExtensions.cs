using Contracts;
using Entities;
using LoggingService;
using Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TarotApi
{
    public static class ServiceExtensions
    {

        //refresher:
        // CORS gives the user rights to access resources from the server from a different domin
        // this is mandatory if the client-side is on a different domain

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                                        .AllowAnyMethod()
                                        .AllowAnyHeader());                                        
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            // just use default params
            services.Configure<IISOptions>(options =>
            {

            });
        }
        
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggingManager, LoggingManager>();
        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
            /*
             * var connectionString = config["dbConnection:connectionString"];
            services.AddDbContextPool<RepositoryContext>(x => x.UseSqlServer(connectionString), x => x.MigrationsAssembly("TarotTracker.Entities"));
            */

            services.AddDbContext<RepositoryContext>(options =>
            options.UseSqlServer(config.GetConnectionString("TarotDb")));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
