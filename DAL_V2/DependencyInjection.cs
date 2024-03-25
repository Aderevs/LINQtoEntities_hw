using DAL_V2.Interfaces;
using DAL_V2.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DAL_V2
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection service)
        {
            service.AddScoped<ICartRepository, CartRepository>();
            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<IKeyParamsRepository, KeyParamsRepository>();
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IWordRepository, WordRepository>();

            return service;
        }
    }
}