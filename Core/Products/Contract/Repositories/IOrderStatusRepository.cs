using App.Domain.Core.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contract.Repositories
{
    public interface IOrderStatusRepository
    {
        Task<int> Add(OrderStatusInputDto inputDto, CancellationToken cancellationToken);
        Task<int> Update(int id, OrderStatusInputDto inputDto, CancellationToken cancellationToken);
        Task<int> Delete(int Id, CancellationToken cancellationToken);
        Task<List<OrderStatusOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<OrderStatusOutputDto> GetById(int Id, CancellationToken cancellationToken);
    }
}
