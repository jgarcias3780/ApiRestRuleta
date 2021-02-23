using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RuletaClean.Core.Entities;
using RuletaClean.Core.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RuletaClean.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUserLoginService _userLoginService;
        private readonly IConfiguration _configuration;
        public TokenController(IUserLoginService userLoginService, IConfiguration configuration)
        {
            _userLoginService = userLoginService;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Authentication(UserLogin login)
        {
            var user = await _userLoginService.SelectValidUser(login);
            if(user != null)
            {
                var token = GenerateToken(user);
                return Ok(new { token });
            }
            return NotFound();
        }

        private string GenerateToken(UserLogin login)
        {
            //header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,login.user_name),
                new Claim(ClaimTypes.Role,"Administrador"),
            };

            //payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuser"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(2)
            );

            //signature
            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
