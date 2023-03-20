using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebNo3.Models.Authentication
{
    public class Authentication: ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            context.Result = new RedirectToRouteResult(
                new RouteValueDictionary
            {
                {"Controller", "Admin"},
                {"Admin", "Login"},
            });
        }
    }
}
