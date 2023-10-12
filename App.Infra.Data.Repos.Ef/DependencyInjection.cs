using App.Domain.Core.Products.Contract.Repositories;
using App.Domain.Core.Users.Contract.Repositories;
using App.Infra.Data.Repos.Ef.Products;
using App.Infra.Data.Repos.Ef.UOW;
using App.Infra.Data.Repos.Ef.User;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infra.Data.Repos.Ef
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPermissionRepository,PermissionRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();


            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICustomAttributeTemplateRepository, CustomAttributeTemplateRepository>();
            services.AddScoped<IOrdeRepository, OrderRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
