using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem.Controllers
{
    [Authorize]
    [Route("api/assets")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAssets()
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpPost]
        [Authorize(Policy = "AssetManager+")]
        public async Task<IActionResult> CreateAsset()
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsset(Guid id)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpPut("{id:guid}")]
        [Authorize(Policy = "AssetManager+")]
        public async Task<IActionResult> UpdateAsset(Guid id)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ArchiveAsset(Guid id)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpPatch("{id:guid}/status")]
        [Authorize(Policy = "AssetManager+")]
        public async Task<IActionResult> UpdateAssetStatus(Guid id)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpPatch("{id:guid}/condition")]
        [Authorize(Policy = "AssetManager+")]
        public async Task<IActionResult> UpdateAssetCondition(Guid id)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpGet("fields")]
        [Authorize(Policy = "AssetManager+")]
        public async Task<IActionResult> GetAssetFields()
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpGet("{id:guid}/history")]
        [Authorize(Policy = "AssetManager+")]
        public async Task<IActionResult> GetAssetHistory(Guid id)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }
    }
}