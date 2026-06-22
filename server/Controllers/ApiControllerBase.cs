using AssetManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem.Controllers
{
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected ActionResult ToActionResult(ServiceResult result) =>
            result.ErrorType switch
            {
                ServiceErrorType.NotFound => NotFound(new
                {
                    Message = result.ErrorMessage
                }),
                ServiceErrorType.Forbidden => StatusCode(StatusCodes.Status403Forbidden, new
                {
                    Message = result.ErrorMessage
                }),
                ServiceErrorType.BadRequest => BadRequest(new
                {
                    Message = result.ErrorMessage
                }),
                _ => StatusCode(500, new
                {
                    Message = "An unexpected error occurred"
                })
            };

        protected ActionResult ToActionResult<T>(ServiceResult<T> result) =>
            ToActionResult((ServiceResult)result);
    }
}