using App.Domain.Core.Product.Contract.AppServices;
using App.Domain.Core.Product.Contract.Repositories;
using App.Domain.Core.Product.Contract.Services;
using App.Domain.Core.Product.Dtos;
using App.Domain.Services.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Product
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryService _categoryService;

        public CategoryAppService(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<int> Add(CategoryInputDto categoryInputDto, CancellationToken cancellationToken)
        {
            return await _categoryService.Add(categoryInputDto, cancellationToken);
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            return await _categoryService.Delete(id, cancellationToken);
        }

        public async Task<List<CategoryOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _categoryService.GetAll(cancellationToken);
        }

        public async Task<CategoryOutputDto> GetById(int id, CancellationToken cancellationToken)
        {
            return await _categoryService.GetById(id, cancellationToken);
        }

        public async Task<int> Update(int id, CategoryInputDto categoryInputDto, CancellationToken cancellationToken)
        {
            return await _categoryService.Update(id, categoryInputDto, cancellationToken);
        }
    }
}
