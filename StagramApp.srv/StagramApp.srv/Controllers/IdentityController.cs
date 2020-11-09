using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StagramApp.srv.Data.Models;
using StagramApp.srv.Models.Identity;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StagramApp.srv.Controllers
{
    public class IdentityController : ApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationSettings _appSettings;

        protected IdentityController(UserManager<User> userManager, IOptions<ApplicationSettings> appSettings)
        {
            this._userManager = userManager;
            this._appSettings = appSettings.Value;
        }

        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterUserRequestModel data)
        {
            var user = new User
            {
                UserName = data.Username,
                Email = data.Email
            };

            var result = await this._userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
            {
                return this.Ok("User is successfuly registered!");
            }

            return this.BadRequest(result.Errors);
        }

        [Route(nameof(Login))]
        public async Task<ActionResult<string>> Login(LoginUserRequest data)
        {
            var user = await this._userManager.FindByNameAsync(data.Username);

            if (user == null)
            {
                return BadRequest();
            }

            var isValidePassword = await this._userManager.CheckPasswordAsync(user, data.Password);

            if (!isValidePassword)
            {
                return BadRequest();
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(this._appSettings.SecretString);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }
    }
}