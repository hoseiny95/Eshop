using App.Domain.AppServices.Products;
using App.Domain.AppServices.User;
using App.Domain.Core.Products.Contract.AppServices;
using App.Domain.Core.Users.Contract.AppServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryAppService, CategoryAppService>();
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IUserAppServies, UserAppService>();
            return services;
        }
    }
}
