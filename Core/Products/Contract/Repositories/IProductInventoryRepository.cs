using App.Domain.Core.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contract.Repositories
{
    public interface IProductInventoryRepository
    {
        Task<int> Add(ProductInventoryInputDto inputDto, CancellationToken cancellationToken);
        Task<int> Update(int id, ProductInventoryInputDto inputDto, CancellationToken cancellationToken);
        Task<int> Delete(int Id, CancellationToken cancellationToken);
        Task<List<ProductInventoryOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<ProductInventoryOutputDto> GetById(int Id, CancellationToken cancellationToken);
    }
}
