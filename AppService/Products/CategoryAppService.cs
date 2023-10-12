using App.Domain.Core.Products.Contract.AppServices;
using App.Domain.Core.Products.Contract.Repositories;
using App.Domain.Core.Products.Contract.Services;
using App.Domain.Core.Products.Dtos;
using App.Domain.Core.Users.Contract.Services;
using App.Domain.Services.Products;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Products
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryService _categoryService;
        private readonly IUserServise _userService;

        public CategoryAppService(ICategoryService categoryService
                                    , IUserServise userService
                                    )
        {
            _categoryService = categoryService;
            _userService = userService;
        }

        public async Task<int> Add(CategoryInputDto categoryInputDto, CancellationToken cancellationToken)
        {
            return await _categoryService.Add(categoryInputDto, cancellationToken);
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
          
            //_userService.CheckPermissionByRoleId(, cancellationToken, "Deleted");
            return await _categoryService.Delete(id, cancellationToken);
        }

        public async Task<List<CategoryOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _categoryService.GetAll(cancellationToken);
        }

        public async Task<CategoryOutputDto> GetById(int id, CancellationToken cancellationToken)
        {
            return await _categoryService.GetById(id, cancellationToken);
        }

        public async Task<int> Update(int id, CategoryInputDto categoryInputDto, CancellationToken cancellationToken)
        {
            return await _categoryService.Update(id, categoryInputDto, cancellationToken);
        }
    }
}
