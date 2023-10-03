using App.Domain.Core.Products.Contract.Repositories;
using App.Domain.Core.Products.Dtos;
using App.Domain.Core.Products.Entities;
using App.Infra.Data.SqlServer.Ef.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly Maktab97ShopDbContext _db;

        public ProductRepository(Maktab97ShopDbContext db)
        {
            _db = db;
        }
        public async Task<int> Add(ProductInputDto productInputDto, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Title = productInputDto.Title,
                CategoryId = productInputDto.CategoryId,
                CalculatedQty = productInputDto.CalculatedQty,
                Category = productInputDto.Category
            };
            await _db.AddAsync(product, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
            return product.Id;

        }

        public async Task<int> Update(ProductInputDto productInputDto, CancellationToken cancellationToken)
        {
            var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == productInputDto.Id);

            product.Title = productInputDto.Title;
            product.CategoryId = productInputDto.CategoryId;
            product.CalculatedQty = productInputDto.CalculatedQty;

            await _db.SaveChangesAsync(cancellationToken);
            return product.Id;

        }

        public async Task<int> Delete(int Id, CancellationToken cancellationToken)
        {
            var product = await _db.Products.FindAsync(Id);
            product.IsRemoved = true;
            await _db.SaveChangesAsync();
            return product.Id;
        }

        public async Task<List<ProductOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            var products = _db.Products.AsNoTracking().Select(product => new ProductOutputDto
            {
                Id = product.Id,
                CalculatedQty = product.CalculatedQty,
                Title = product.Title,
                CategoryId = product.CategoryId,
            });
            return products.ToList();
        }

        public async Task<ProductOutputDto> GetById(int Id, CancellationToken cancellationToken)
        {
            var product = await  _db.Products.FirstOrDefaultAsync(p => p.Id == Id);
            var productOutPut = new ProductOutputDto()
            {
                Id = product.Id,
                Title = product.Title,
                CategoryId = product.CategoryId,
                CalculatedQty = product.CalculatedQty,
            };
            return productOutPut;
        }
    }
}


