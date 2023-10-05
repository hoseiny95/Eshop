using App.Domain.Core.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contract.Repositories
{
    public interface ICustomAttributeTemplateRepository
    {
        Task<int> Add(CustomAttributeTemplateInputDto customAttributeInputDto, CancellationToken cancellationToken);
        Task<int> Update(int id,CustomAttributeTemplateInputDto customAttributeInputDto, CancellationToken cancellationToken);
        Task<int> Delete(int Id, CancellationToken cancellationToken);
        Task<List<CustomAttributeTemplateOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<CustomAttributeTemplateOutputDto> GetById(int Id, CancellationToken cancellationToken);
    }
}
