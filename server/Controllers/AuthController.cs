using AssetManagementSystem.DTOs.Auth.Requests;
using AssetManagementSystem.DTOs.Auth.Responses;
using AssetManagementSystem.Extensions;
using AssetManagementSystem.Models.Entities;
using AssetManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiControllerBase
    {
        private readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<AccessTokenDto>> Login([FromBody] LoginRequest request)
        {
            var result = await _userService.Login(request, Response);
            return result.Succeeded ? Ok(result.Value) : ToActionResult(result);
        }

        [HttpGet("refresh")]
        public async Task<ActionResult<AccessTokenDto>> Refresh()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            if (refreshToken == null) return Unauthorized();

            var result = await _userService.Refresh(HttpContext.GetCurrentUser(), refreshToken, Response);
            return result.Succeeded ? Ok(result.Value) : ToActionResult(result);
        }

        [AllowAnonymous]
        [HttpGet("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
        {
            var result = await _userService.ResetPassword(request)  ;
            return result.Succeeded ? NoContent() : ToActionResult(result);
        }

        [HttpGet("Me")]
        public ActionResult<User> Me()
        {
            User user = HttpContext.GetCurrentUser();

            return Ok(user);
        }

        [Authorize(Policy = "AssetManager+")]
        [HttpGet("AssetManager")]
        public ActionResult<User> Manager()
        {
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Admin")]
        public ActionResult<User> Admin()
        {
            return Ok();
        }

        [HttpGet("Debug")]
        public IActionResult Debug()
        {
            return Ok(User.Claims.Select(c => new
            {
                c.Type,
                c.Value
            }));
        }
    }
}
