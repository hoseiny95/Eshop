using App.Domain.Core.Product.Contract.Repositories;
using App.Domain.Core.Product.Contract.Services;
using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Product
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Add(CategoryInputDto categoryInputDto, CancellationToken cancellationToken)
        {
            return await _repository.Add(categoryInputDto, cancellationToken);
        }
    }
}
