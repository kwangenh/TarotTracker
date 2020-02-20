using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
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
                                        .AllowAnyHeader()
                                        .WithMethods("POST", "GET", "PUT"));
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            // just use default params
            services.Configure<IISOptions>(options =>
            {

            });
        }
    }
}
