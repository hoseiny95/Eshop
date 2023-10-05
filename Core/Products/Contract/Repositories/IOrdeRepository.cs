using App.Domain.Core.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contract.Repositories
{
    public interface IOrdeRepository
    {
        Task<int> Add(OrderInputDto inputDto, CancellationToken cancellationToken);
        Task<int> Update(int id,OrderInputDto inputDto, CancellationToken cancellationToken);
        Task<int> Delete(int Id, CancellationToken cancellationToken);
        Task<List<OrderOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<OrderOutputDto> GetById(int Id, CancellationToken cancellationToken);
    }
}
