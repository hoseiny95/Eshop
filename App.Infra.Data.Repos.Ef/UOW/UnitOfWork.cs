using App.Domain.Core.Products.Contract.Repositories;
using App.Infra.Data.Repos.Ef.Products;
using App.Infra.Data.SqlServer.Ef.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Maktab97ShopDbContext _dbContext;
        public IProductRepository Products { get; }

        public ICategoryRepository Categories { get; }

        public ICustomAttributeTemplateRepository CustomAttributes { get; }

        public IOrdeRepository Orders { get; }

        public IOrderLineRepository OrderLines { get; }

        public IOrderStatusRepository OrderStatuses { get; }

        public IProductCustomAttributeRepository ProductCustomAttributes { get; }

        public IProductInventoryRepository ProductInventories { get; }

        public IProductPriceRepository ProductPrices { get; }

        public UnitOfWork(Maktab97ShopDbContext dbContext ,IMapper mapper)
        {
            _dbContext = dbContext;
            Products = new ProductRepository(_dbContext);
            Orders = new OrderRepository(mapper,_dbContext);
            CustomAttributes = new CustomAttributeTemplateRepository(mapper,_dbContext);
            Categories = new CategoryRepository(_dbContext);
        }
        public void Dispose() => _dbContext.Dispose();

        public async Task<int> SavechangesAsync() =>  await _dbContext.SaveChangesAsync();
    }
}
