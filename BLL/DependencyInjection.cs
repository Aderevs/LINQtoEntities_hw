using AutoMapper;
using BLL.Entity;
using BLL.Interfaces.Repository;
using BLL.Interfaces.Services;
using BLL.Repository;
using BLL.Services;
using DAL_V2;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    internal class MaperService : Profile
    {
        public MaperService()
        {
            CreateMap<DAL_V2.Entity.Cart, Cart>().ReverseMap();
            CreateMap<DAL_V2.Entity.Category, Category>().ReverseMap();
            CreateMap<DAL_V2.Entity.KeyParams, KeyParams>().ReverseMap();
            CreateMap<DAL_V2.Entity.Product, Product>().ReverseMap();
            CreateMap<DAL_V2.Entity.User, User>().ReverseMap();
            CreateMap<DAL_V2.Entity.Word, Word>().ReverseMap();
        }
    }

    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services, IConfiguration configuration)
        {
			services.AddDataAccessLayer();
            services.AddAutoMapper(typeof(MaperService));


            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IKeyParamsRepository, KeyParamsRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWordRepository, WordRepository>();


            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<ICategoryServices, CategoryServices>();

            return services;
        }
    }
}
