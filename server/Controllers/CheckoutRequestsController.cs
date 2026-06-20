using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ThreatlockerAssetManagementSystem.Controllers
{
    [Authorize]
    [Route("api/checkout-requests")]
    [ApiController]
    public class CheckoutRequestsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCheckoutRequests()
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCheckoutRequest()
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCheckoutRequest(Guid id)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ArchiveCheckoutRequest(Guid id)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpPatch("{id:guid}/cancel")]
        public async Task<IActionResult> CancelCheckoutRequest(Guid id)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpPatch("{id:guid}/approve")]
        [Authorize(Policy = "AssetManager+")]
        public async Task<IActionResult> ApproveCheckoutRequest(Guid id)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpPatch("{id:guid}/reject")]
        [Authorize(Policy = "AssetManager+")]
        public async Task<IActionResult> RejectCheckoutRequest(Guid id)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpPatch("{id:guid}/assign-asset")]
        [Authorize(Policy = "AssetManager+")]
        public async Task<IActionResult> AssignCheckoutRequest(Guid id)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpPatch("{id:guid}/return")]
        [Authorize(Policy = "AssetManager+")]
        public async Task<IActionResult> ReturnCheckoutRequest(Guid id)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }
    }
}
