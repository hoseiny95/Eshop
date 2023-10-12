using App.Domain.Core.Products.Contract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Users.Contract.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }

        ICategoryRepository Categories { get; }

        ICustomAttributeTemplateRepository CustomAttributes { get; }

        IOrdeRepository Orders { get; }

        IOrderLineRepository OrderLines { get; }

        IOrderStatusRepository OrderStatuses { get; }

        IProductCustomAttributeRepository ProductCustomAttributes { get; }

        IProductInventoryRepository ProductInventories { get; }

        IProductPriceRepository ProductPrices { get; }
        Task<int> SavechangesAsync();

        IRoleRepository RoleRepository {get;}

    }
}
