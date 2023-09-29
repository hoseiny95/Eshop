using App.Domain.AppServices.Product;
using App.Domain.Core.Product.Contract.AppServices;
using App.Domain.Core.Product.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Endpoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICategoryAppService _categoryAppService;

        public ProductController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        [HttpPost ("AddCategory")]
        public async Task<IActionResult> Add(CategoryInputDto categoryInputDto, CancellationToken cancellationToken)
        {
            return Ok(await _categoryAppService.Add(categoryInputDto, cancellationToken));
        }
    }
}
