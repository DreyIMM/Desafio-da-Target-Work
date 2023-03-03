using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.Infrastructure.ExtensionMethods
{
    public static class CommonInjectDependence
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            services.AddScoped<Interfaces.IClientViewModelService, Services.ClientViewModelService>();
            services.AddScoped<Interfaces.IProductViewModelService, Services.ProductViewModelService>();


            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<Domain.Interfaces.ICategoryRepository, Data.Repositories.CategoryRepository>();
            services.AddScoped<Domain.Interfaces.IClientRepository, Data.Repositories.ClientRepository>();
            services.AddScoped<Domain.Interfaces.IProductRepository, Data.Repositories.ProductRepository>();


            return services;
        }
    }
}
