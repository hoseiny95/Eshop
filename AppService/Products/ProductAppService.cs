using App.Domain.Core.Products.Contract.AppServices;
using App.Domain.Core.Products.Contract.Services;
using App.Domain.Core.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Products
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _productService;

        public ProductAppService(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<GeneralOutputDto> CreateProduct(ProductInputDto productInputDto, CancellationToken cancellationToken)
        {
            var product = await _productService.CreateProduct(productInputDto, cancellationToken);
            string msg = null;
            if (product == 0)
            {
                msg = "Product NotCreated";
            }
            else
            {
                msg = "Product Created";
            }

          return  new GeneralOutputDto()
            {
                Id = product,
                Messeage = msg
            };
        }

        public async Task<GeneralOutputDto> Update(ProductInputDto productInputDto, CancellationToken cancellationToken)
        {
            var product = await _productService.Update(productInputDto, cancellationToken);
            string msg = null;
            if (product == 0)
            {
                msg = "Product NotCreated";
            }
            else
            {
                msg = "Product Created";
            }

            return new GeneralOutputDto()
            {
                Id = product,
                Messeage = msg
            };
        }

        public async Task<GeneralOutputDto> Delete(int Id, CancellationToken cancellationToken)
        {
            var product = await _productService.Delete(Id, cancellationToken);
            string msg = null;
            if (product == 0)
            {
                msg = "Product NotCreated";
            }
            else
            {
                msg = "Product Created";
            }

            return new GeneralOutputDto()
            {
                Id = product,
                Messeage = msg
            };
        }

        public async Task<List<ProductOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _productService.GetAll(cancellationToken);
        }

        public async Task<ProductOutputDto> GetById(int Id, CancellationToken cancellationToken)
        {
            return await _productService.GetById(Id, cancellationToken);
        }
    }
}
