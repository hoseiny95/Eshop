using App.Domain.Core.Products.Contract.Repositories;
using App.Domain.Core.Products.Dtos;
using App.Domain.Core.Products.Entities;
using App.Infra.Data.SqlServer.Ef.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Products
{


    public class CustomAttributeTemplateRepository : ICustomAttributeTemplateRepository
    {
        private readonly IMapper _mapper;
        private readonly Maktab97ShopDbContext _dbContext;

        public CustomAttributeTemplateRepository(IMapper mapper, Maktab97ShopDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<int> Add(CustomAttributeTemplateInputDto InputDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CustomAttributeTemplate>(InputDto);
            await _dbContext.CustomAttributeTemplates.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<int> Delete(int Id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.CustomAttributeTemplates.FindAsync(Id, cancellationToken);
            _dbContext.CustomAttributeTemplates.Remove(entity);
            return Id;
        }


        public async Task<List<CustomAttributeTemplateOutputDto>> GetAll(CancellationToken cancellationToken)
            => _mapper.Map<List<CustomAttributeTemplateOutputDto>>(await _dbContext.CustomAttributeTemplates.ToListAsync(cancellationToken));



        public async Task<CustomAttributeTemplateOutputDto> GetById(int Id, CancellationToken cancellationToken)
            => _mapper.Map<CustomAttributeTemplateOutputDto>(await _dbContext.CustomAttributeTemplates.FirstOrDefaultAsync(x => x.Id == Id , cancellationToken));


        public async Task<int> Update(int id, CustomAttributeTemplateInputDto InputDto, CancellationToken cancellationToken)
        {
            var entity =await _dbContext.CustomAttributeTemplates.FindAsync(id,cancellationToken);
            entity.CategoryId = InputDto.CategoryId;
            entity.AttributeTitle = InputDto.AttributeTitle;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return id;
        }
    }
}
