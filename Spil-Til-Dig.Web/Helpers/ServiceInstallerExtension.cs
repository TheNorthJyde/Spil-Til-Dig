using Microsoft.Extensions.DependencyInjection;
using Spil_Til_Dig.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Web.Helpers
{
    public static class ServiceInstallerExtension
    {
        public static IServiceCollection InstallServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}
