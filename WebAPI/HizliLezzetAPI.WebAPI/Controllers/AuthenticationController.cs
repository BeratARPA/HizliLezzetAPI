using HizliLezzetAPI.Application.Services;
using HizliLezzetAPI.Application.Wrappers;
using HizliLezzetAPI.Domain.Entities;
using HizliLezzetAPI.WebApi.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpGet("WhoAmI")]
        public async Task<IActionResult> WhoAmI()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(new ServiceResponse<ApplicationUser>(user));
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

            return BadRequest(new ServiceResponse<string>("Invalid register."));
        }
    }
}
