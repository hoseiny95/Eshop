using App.Domain.Core.Product.Contract.Repositories;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
using App.Infra.Data.SqlServer.Ef.Models;

namespace App.Infra.Data.Repos.Ef.Product
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
    }
}