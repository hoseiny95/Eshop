using App.Domain.Core.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contract.Repositories
{
    public interface IProductPriceRepository
    {
        Task<int> Add(ProductPriceInputDto inputDto, CancellationToken cancellationToken);
        Task<int> Update(int id, ProductPriceInputDto inputDto, CancellationToken cancellationToken);
        Task<int> Delete(int Id, CancellationToken cancellationToken);
        Task<List<ProductPriceOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<ProductPriceOutputDto> GetById(int Id, CancellationToken cancellationToken);
    }
}
