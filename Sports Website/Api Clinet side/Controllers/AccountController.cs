using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Api_Clinet_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _config;
        public AccountController(UserManager<IdentityUser> userManager , SignInManager<IdentityUser> signInManager , IConfiguration config)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._config = config;
        }
        [HttpPost]
        public async Task<ActionResult> Login(LogInVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                
                if (!result.Succeeded)
                    return NotFound($"User {model.UserName} Not Found");

                var loginUser = await _userManager.FindByNameAsync(model.UserName);

                // generate token
                var token = GenerateToken(loginUser);
                return Ok(new {Token = token});                
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        private string GenerateToken(IdentityUser model)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("jwt:key")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier , model.UserName),
                new Claim(ClaimTypes.Email , model.Email)

            };

            var token = new JwtSecurityToken(
                _config.GetValue<string>("jwt:Issuer"),
                _config.GetValue<string>("jwt:Audience"),
                claims, 
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials:credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
