using App.Domain.Core.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contract.Repositories
{
    public interface IOrderLineRepository
    {
        Task<int> Add(OrderLineInputDto inputDto, CancellationToken cancellationToken);
        Task<int> Update(int id, OrderLineInputDto inputDto, CancellationToken cancellationToken);
        Task<int> Delete(int Id, CancellationToken cancellationToken);
        Task<List<OrderLineOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<OrderLineOutputDto> GetById(int Id, CancellationToken cancellationToken);
    }
}
