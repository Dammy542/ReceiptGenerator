using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ReceiptGenerator.Core.Helpers;
using System.Net;

namespace ReceiptGenerator.Api.Attribute;

/// <summary>
/// Use to ensure the validation passes for the input 
/// </summary>
public class ValidationFilterAttribute : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var error = new UnprocessableEntityObjectResult(context.ModelState);
            var response = new ApiResponse((int)HttpStatusCode.BadRequest, "Validation failed", error.Value);

            context.Result = new JsonResult(response)
            {
                StatusCode = 400
            };
        }
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}