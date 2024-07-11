using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Final_project_2.ActionFilter
{
    public class AddJwtTokenFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Check if the action has [AllowAnonymous] attribute
            var endpoint = context.HttpContext.GetEndpoint();
            var allowAnonymous = endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null;

            if (!allowAnonymous)
            {
                var token = context.HttpContext.Session.GetString("token");
                if (!string.IsNullOrEmpty(token))
                {
                    context.HttpContext.Request.Headers.Add("Authorization", $"Bearer {token}");
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
