using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ChallengeAlkemy.Entities;
using ChallengeAlkemy.ViewModels.Login;
using ChallengeAlkemy.ViewModels.Register;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ChallengeAlkemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthenticationController(UserManager<User> userManager,
            SignInManager<User> singInManager)
        {
            _userManager = userManager;
            _signInManager = singInManager;

        }

        #region Registro
        [HttpPost]
        [Route("Registro")]
        public async Task<IActionResult> Register(RegisterRequestModel model)
        {
            var userExist = await _userManager.FindByNameAsync(model.UserName);

            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                IsActive = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                new
                {
                    Status = "Error",
                    Message = $"User Creation Failed! Errors:{string.Join(",", result.Errors.Select(x => x.Description))}"
                });
            }

            return Ok(new
            {
                Status = "Succes",
                Message = "User Created Succesfully!!"
            });
        }
        #endregion
        #region Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var currentUser = await _userManager.FindByNameAsync(model.UserName);
                if (currentUser.IsActive)
                {
                    return Ok(await GetToken(currentUser));
                }

            }
            return StatusCode(StatusCodes.Status401Unauthorized,
                new
                {
                    Status = "Error",
                    Message = $"El usuario {model.UserName} no esta autorizado!"
                });

        }

        private async Task<LoginResponseViewModel> GetToken(User currentUser)
        {
            var userRoles = await _userManager.GetRolesAsync(currentUser);

            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, currentUser.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            authClaims.AddRange(userRoles.Select(x => new Claim(ClaimTypes.Role, x)));

            var authSigninKEy = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeySecretaSuperLargaDeAUTORIZACION"));

            var token = new JwtSecurityToken(issuer: "https://localhost:44314",
                audience: "https://localhost:44314",
                expires: DateTime.Now.AddHours(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKEy, SecurityAlgorithms.HmacSha256));

            return new LoginResponseViewModel
            {

                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ValidTo = token.ValidTo

            };


        }
    }

}
#endregion