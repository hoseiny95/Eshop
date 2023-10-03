using App.Domain.Core.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contract.AppServices
{
    public interface IProductAppService
    {
        Task<GeneralOutputDto> CreateProduct(ProductInputDto productInputDto, CancellationToken cancellationToken);
        Task<GeneralOutputDto> Update(ProductInputDto productInputDto, CancellationToken cancellationToken);
        Task<GeneralOutputDto> Delete(int Id, CancellationToken cancellationToken);
        Task<List<ProductOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<ProductOutputDto> GetById(int Id, CancellationToken cancellationToken);
    }
}
