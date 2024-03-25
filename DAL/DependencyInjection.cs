using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(options =>
            {
                return new EntityDatabase(configuration.GetConnectionString("DbConnect"));
            });
            services.AddScoped<IProductRepositoryDAL, ProductRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
			

			return services;
        }
    }
}
