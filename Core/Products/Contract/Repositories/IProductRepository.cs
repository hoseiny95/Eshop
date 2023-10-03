using App.Domain.Core.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contract.Repositories
{
    public interface IProductRepository
    {
        Task<int> Add(ProductInputDto productInputDto, CancellationToken cancellationToken);
        Task<int> Update(ProductInputDto productInputDto, CancellationToken cancellationToken);
        Task<int> Delete(int Id, CancellationToken cancellationToken);
        Task<List<ProductOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<ProductOutputDto> GetById(int Id, CancellationToken cancellationToken);
    }
}
