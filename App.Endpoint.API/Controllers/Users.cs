using App.Domain.Core.Users.Contract.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Endpoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public Users(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("RoleTest")]
        public async Task<IActionResult> GetRolesByUserId(int userId)
        {
            var result = await _unitOfWork.RoleRepository.GetRolesByUserId(userId);
            return Ok(result);
        }
    }
}
