using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EMR.Infrastructure
{
    public class CustomAuthorizationFilter : IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            if (context.HttpContext.Session.GetString("key") == null)
            {
                context.Result = new RedirectResult("~/Home/InvalidSession");
            }
        }

    }
}