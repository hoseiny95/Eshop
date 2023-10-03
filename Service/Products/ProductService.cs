using App.Domain.Core.Products.Contract.Repositories;
using App.Domain.Core.Products.Contract.Services;
using App.Domain.Core.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Products
{

    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> CreateProduct(ProductInputDto productInputDto, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById(productInputDto.Id, cancellationToken);
            if (product != null)
            {
                return await _repository.Add(productInputDto, cancellationToken);
            }

            return 0;
        }

        public async Task<int> Update(ProductInputDto productInputDto, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById(productInputDto.Id, cancellationToken);
            if (product != null)
            {
                return await _repository.Add(productInputDto, cancellationToken);
            }

            return 0;
        }

        public async Task<int> Delete(int Id, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById(Id, cancellationToken);
            if (product != null)
            {
                return await _repository.Delete(Id, cancellationToken);
            }

            return 0;
        }

        public async Task<List<ProductOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }

        public Task<ProductOutputDto> GetById(int Id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

