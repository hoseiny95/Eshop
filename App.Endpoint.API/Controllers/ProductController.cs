using App.Domain.AppServices.Products;
using App.Domain.Core.Products.Contract.AppServices;
using App.Domain.Core.Products.Dtos;
using App.Domain.Core.Users.Contract.AppServices;
using App.Domain.Core.Users.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjMiLCJleHAiOjE2OTY1ODY2NDIsImlzcyI6IkVTb3AifQ.WDYSdvLNazAeiYxZoayWK00Kr8eN1FTJCFmdJHypPwY


namespace App.Endpoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICategoryAppService _categoryAppService;
        private readonly IUserAppServies _userAppServies;

        public ProductController(ICategoryAppService categoryAppService,IUserAppServies userAppServies)
        {
            _userAppServies = userAppServies;
            _categoryAppService = categoryAppService;

        }

        [HttpPost ("Register")]
        public async Task<IActionResult> Register(RegisterInputDto dto)
        {
            var token = await _userAppServies.Register(dto);
            return Ok(token);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var h = HttpContext.Request.Headers;
            var y = HttpContext.User.Identity.IsAuthenticated;
            var x = HttpContext.User.Identity.Name;
            var token =await _userAppServies.Login(dto);
            return Ok(token);
        }


        [HttpPost ("AddCategory")]
        public async Task<IActionResult> Add(CategoryInputDto categoryInputDto, CancellationToken cancellationToken)
        {
            return Ok(await _categoryAppService.Add(categoryInputDto, cancellationToken));
        }

        [HttpGet ("GetAllCategory")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _categoryAppService.GetAll(cancellationToken));
        }

        [HttpGet ("GetByIdCategory")]
        public async Task<IActionResult> GetById(int id , CancellationToken cancellationToken)
        {
            return Ok(await _categoryAppService.GetById(id, cancellationToken));
        }


        [HttpPut ("UpdateCategory")]
        public async Task<IActionResult> Update(int id ,CategoryInputDto categoryInput, CancellationToken cancellationToken)
        {
            return Ok(await _categoryAppService.Update(id, categoryInput, cancellationToken));
        }


        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            return Ok(await _categoryAppService.Delete(id, cancellationToken));
        }
    }
}
