using App.Domain.Core.Product.Contract.Repositories;
using App.Domain.Core.Product.Contract.Services;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
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



        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var category = await _repository.GetById(id, cancellationToken);
            if (category != null)
            {
                await _repository.Delete(category, cancellationToken);
                return true;
            }
            return false;
        }

        public async Task<List<CategoryOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }

        public async Task<CategoryOutputDto> GetById(int id, CancellationToken cancellationToken)
        {
            return await _repository.GetById(id, cancellationToken);
        }

        public async Task<int> Update(int id, CategoryInputDto categoryInputDto, CancellationToken cancellationToken)
        {
            return await _repository.Update(id, categoryInputDto, cancellationToken);
        }
    }
}
