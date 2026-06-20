using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ThreatlockerAssetManagementSystem.DTOs.Pagination;
using ThreatlockerAssetManagementSystem.DTOs.Users;
using ThreatlockerAssetManagementSystem.Enums;
using ThreatlockerAssetManagementSystem.Helpers;
using ThreatlockerAssetManagementSystem.Models.Entities;
using ThreatlockerAssetManagementSystem.Repositories;

namespace ThreatlockerAssetManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        public UsersController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<User>>> GetUsers([FromQuery] GetUsersRequest request)
        {
            PagedResponse<User> users = await _userRepository.GetUsersAsync(request);

            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] CreateUserRequest request)
        {
            if (!Enum.IsDefined(typeof(Role), request.Role))
                return BadRequest("Invalid role");

            bool userExists = await _userRepository.GetUserByEmailAsync(request.EmailAddress) != null;
            if (userExists) return BadRequest("Email Address is taken");

            User user = await _userRepository.CreateUserAsync(request);

            return Ok(user);
        }

        [HttpPatch("{id}/role")]
        public async Task<ActionResult<User>> UpdateUserRole(Guid id, [FromBody] UpdateUserRoleRequest request)
        {
            if (!Enum.IsDefined(typeof(Role), request.Role))
                return BadRequest("Invalid role");

            User? user = await _userRepository.UpdateUserRole(id, request.Role);

            if (user == null) return BadRequest("Invalid user id");

            return Ok(user);
        }

        [HttpPatch("{id}/active")]
        public async Task<IActionResult> UpdateUserActiveStatus(Guid id, UpdateUserActiveRequest request)
        {
            User? user = await _userRepository.UpdateUserActive(id, request.IsActive);

            if (user == null) return BadRequest("Invalid user id");

            return Ok(user);
        }
    }
}