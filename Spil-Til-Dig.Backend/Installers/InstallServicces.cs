using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spil_Til_Dig.Backend.Repos;
using Spil_Til_Dig.Backend.Services;
using Spil_Til_Dig.Backend.Services.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Backend.Installers
{
    public class InstallServicces : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            #region Repos
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IGenreRepo, GenreRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IKeyRepo, KeyRepo>();
            #endregion

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IGenreSerivce, GenreService>();
            services.AddScoped<IPayPalService, PayPalService>();
            services.AddScoped<IUserService, UserService>();
#if DEBUG
            services.AddScoped<ISeedService, SeedService>();
#endif
        }
    }
}
