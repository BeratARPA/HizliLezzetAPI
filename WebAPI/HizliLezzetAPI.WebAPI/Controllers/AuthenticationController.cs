using HizliLezzetAPI.Application.Services;
using HizliLezzetAPI.Application.Wrappers;
using HizliLezzetAPI.Domain.Entities;
using HizliLezzetAPI.WebApi.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HizliLezzetAPI.WebApi.Controllers
{
    public class AuthenticationController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly JwtTokenGenerator tokenGenerator;

        public AuthenticationController(UserManager<ApplicationUser> userManager, JwtTokenGenerator tokenGenerator, IMediator mediator) : base(mediator)
        {
            this.userManager = userManager;
            this.tokenGenerator = tokenGenerator;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(loginDto.Email);

                if (user != null && await userManager.CheckPasswordAsync(user, loginDto.Password))
                {
                    var token = tokenGenerator.GenerateJwtToken(user.Id.ToString(), user.UserName, user.Email);

                    return Ok(new ServiceResponse<string>(token));
                }

                ModelState.AddModelError(string.Empty, "Invalid login.");
            }

            return BadRequest(new ServiceResponse<string>("Invalid login."));
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    UserName = registerDto.UserName,
                    Email = registerDto.Email,
                    Bio = " "
                };

                var result = await userManager.CreateAsync(user, registerDto.Password);

                if (result.Succeeded)
                {
                    var token = tokenGenerator.GenerateJwtToken(user.Id.ToString(), user.UserName, user.Email);

                    return Ok(new ServiceResponse<string>(token));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return BadRequest(new ServiceResponse<string>("Invalid login."));
        }

        [HttpPost("Logout")]
        public IActionResult Logout([FromBody] LogoutDto logoutDto)
        {
            return Ok();
        }
    }
}
