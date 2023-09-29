using App.Domain.Core.Product.Contract.Repositories;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
using App.Infra.Data.SqlServer.Ef.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Products
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Maktab97ShopDbContext _maktab97ShopDbContext;

        public CategoryRepository(Maktab97ShopDbContext maktab97ShopDbContext)
        {
            _maktab97ShopDbContext = maktab97ShopDbContext;
        }

        public async Task<int> Add(CategoryInputDto categoryInputDto, CancellationToken cancellationToken)
        {
            Category category = new Category()
            {
                Title = categoryInputDto.Title,
                ParentId = categoryInputDto.ParentId,
                HasProducts = categoryInputDto.HasProducts
            };

            await _maktab97ShopDbContext.Categories.AddAsync(category, cancellationToken);
            await _maktab97ShopDbContext.SaveChangesAsync(cancellationToken);

            return category.Id;
        }

        public async Task<bool> Delete(CategoryOutputDto category, CancellationToken cancellationToken)
        {
            var DeleteCategory = new Category()
            {
                Id = category.Id,
                Title = category.Title,
                ParentId = category.ParentId,
                HasProducts = category.HasProducts

            };
            _maktab97ShopDbContext.Categories.Remove(DeleteCategory);

           var isRemoved =  await _maktab97ShopDbContext.SaveChangesAsync(cancellationToken);

            if (isRemoved > 0)
                return true;
            return false;

        }

        public async Task<List<CategoryOutputDto>> GetAll(CancellationToken cancellationToken)
        {
           var categories = await _maktab97ShopDbContext.Categories.Select(c => new CategoryOutputDto()
            {
                Id = c.Id,
                Title = c.Title,
                ParentId = c.ParentId,
                HasProducts = c.HasProducts,
                Products = c.Products.Select(c => new ProductOutputDto
                {
                    Title = c.Title,
                    CalculatedQty = c.CalculatedQty,
                    CategoryId = c.CategoryId,

                }).ToList(),

            }).ToListAsync(cancellationToken);
            return categories;
        }

        public async Task<CategoryOutputDto> GetById(int id, CancellationToken cancellationToken)
        {
            var category = await _maktab97ShopDbContext.Categories.Select(c => new CategoryOutputDto
            {
                Id = id,
                Title= c.Title,
                ParentId = c.ParentId,
                HasProducts = c.HasProducts,
                Products = c.Products.Select(c => new ProductOutputDto
                {
                    Title= c.Title,
                    CalculatedQty = c.CalculatedQty,
                    CategoryId = c.CategoryId,

                }).ToList(),

                
            }).FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

            return category;
            
        }

      
        public async Task<int> Update(int id, CategoryInputDto categoryInputDto, CancellationToken cancellationToken)
        {
            var category = await _maktab97ShopDbContext.Categories.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            category.Title = categoryInputDto.Title;
            category.ParentId = categoryInputDto.ParentId;
            category.HasProducts = categoryInputDto.HasProducts;
            await _maktab97ShopDbContext.SaveChangesAsync(cancellationToken);
            return category.Id;
        }
    }
}