using AssetCheckoutSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace AssetCheckoutSystem.Controllers
{
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected ActionResult ToActionResult(ServiceResult result) =>
            result.ErrorType switch
            {
                ServiceErrorType.ResourceNotFound => NotFound(),
                ServiceErrorType.Unauthorized => Unauthorized(),
                ServiceErrorType.AccessDenied => StatusCode(StatusCodes.Status403Forbidden, new
                {
                    Title = result.ErrorMessage
                }),
                ServiceErrorType.InvalidOperation => BadRequest(new
                {
                    Title = result.ErrorMessage
                }),
                _ => StatusCode(500, new
                {
                    Title = "An unexpected error occurred"
                })
            };

        protected ActionResult ToActionResult<T>(ServiceResult<T> result) =>
            ToActionResult((ServiceResult)result);
    }
}