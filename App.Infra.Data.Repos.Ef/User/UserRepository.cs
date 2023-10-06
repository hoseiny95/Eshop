using App.Domain.Core.Users.Contract.Repositories;
using App.Domain.Core.Users.Dtos;
using App.Domain.Core.Users.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace App.Infra.Data.Repos.Ef.User
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public UserRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        private JwtSecurityToken GetToken(int userId)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("salamll08909767855677575ff"));
            var clamsList = new List<Claim> { new Claim("id", userId.ToString()) };
            var token = new JwtSecurityToken(
                issuer: "ESop",
                expires: DateTime.Now.AddMinutes(30),
                claims: clamsList,
                signingCredentials : new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }
        public async Task<string> Login(LoginDto Dto)
        {
            var user =await _userManager.FindByNameAsync(Dto.Username);
            if (user != null)
            {
                var res =await _userManager.CheckPasswordAsync(user, Dto.Password);
                if (res)
                {
                    var token =  GetToken(user.Id);
                    var tk = new JwtSecurityTokenHandler().WriteToken(token);
                    return tk;
                }
            }
            return null;
        }

        public async Task<string> Register(RegisterInputDto inputDto)
        {
            var user = new ApplicationUser
            {
                Email = inputDto.Email,
                PasswordHash = inputDto.Password,
                UserName = inputDto.Username
            };
            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                var token =GetToken(user.Id);
                var tk = new JwtSecurityTokenHandler().WriteToken(token);
                return tk;
            }
            return null;
        }
    }
}
