using App.Domain.Core.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contract.Repositories
{
    public interface IProductCustomAttributeRepository
    {
        Task<int> Add(ProductCustomAttributeInputDto inputDto, CancellationToken cancellationToken);
        Task<int> Update(int id, ProductCustomAttributeInputDto inputDto, CancellationToken cancellationToken);
        Task<int> Delete(int Id, CancellationToken cancellationToken);
        Task<List<ProductCustomAttributeOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<ProductCustomAttributeOutputDto> GetById(int Id, CancellationToken cancellationToken);
    }
}
