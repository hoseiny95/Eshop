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
    public class OrderRepository : IOrdeRepository
    {
        private readonly IMapper _mapper;
        private readonly Maktab97ShopDbContext _dbContext;

        public OrderRepository(IMapper mapper, Maktab97ShopDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<int> Add(OrderInputDto InputDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Order>(InputDto);
            await _dbContext.Orders.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<int> Delete(int Id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Orders.FindAsync(Id, cancellationToken);
            _dbContext.Orders.Remove(entity);
            return Id;
        }


        public async Task<List<OrderOutputDto>> GetAll(CancellationToken cancellationToken)
            => _mapper.Map<List<OrderOutputDto>>(await _dbContext.Orders.ToListAsync(cancellationToken));



        public async Task<OrderOutputDto> GetById(int Id, CancellationToken cancellationToken)
            => _mapper.Map<OrderOutputDto>(await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == Id, cancellationToken));


        public async Task<int> Update(int id, OrderInputDto InputDto, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Orders.FindAsync(id,cancellationToken);
            entity.CustomerId = InputDto.CustomerId;
            entity.OrderAt = InputDto.OrderAt;
            entity.StatusId = InputDto.StatusId;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return id;
        }
    }
}
