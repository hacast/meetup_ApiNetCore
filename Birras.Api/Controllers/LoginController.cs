using Birras.Api.Responses;
using Birras.Core.Entities;
using Birras.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Birras.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _iconfiguration;
        private readonly IUserService _userService;
        public LoginController(IConfiguration configuration, IUserService userService )
        {
            this._iconfiguration = configuration;
            this._userService = userService;
        }
        
        /// <summary>
        /// Obtiene un JsonWebToken para un usuario valido
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetToken(UserLogin userLogin)
        {
            //si es valido el user, genero el TOKEN
            var validation = await IsValidUser(userLogin);
            if (validation.Item1)
            {
                var token = GenerateToken(validation.Item2);

                var apiResponse = new ApiResponse<string>(token);
                return Ok(apiResponse);
            }
            else
            {
                return BadRequest("Usuario y/o contraseña incorrectos.");
            }
        }


        private async Task<(bool,Usuario)> IsValidUser(UserLogin userLogin)
        {
            var user = await _userService.GetUserByCredentials(userLogin);
            return (user != null, user);
        }

        private string GenerateToken(Usuario usuario)
        {
            //header
            var _sysk = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_iconfiguration["Authentication:SecretKey"]));
            var signinCredentials = new SigningCredentials(_sysk, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signinCredentials);
            
            //claims
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Nombre),
                new Claim(ClaimTypes.Role,usuario.Rol.ToString()),
            };

            //payload
            var payload = new JwtPayload
            (
                _iconfiguration["Authentication:Issuer"],
                _iconfiguration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(60)
            );

            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
