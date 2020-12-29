using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Technics.com.Services;
using Microsoft.AspNetCore.Mvc;


namespace Technics.com.Attributes
{
    public class AuthorizedAttribute : ActionFilterAttribute
    {
        private Roles role;

        public AuthorizedAttribute(Roles role = Roles.Customer)
        {
            this.role = role;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var serviceUser = (ServiceUser)context.HttpContext.RequestServices.GetService(typeof(ServiceUser));

            if (serviceUser.GetUser() == null)
                context.Result = new UnauthorizedResult();
            else
            if (serviceUser.GetUser().Role == Roles.Customer && role == Roles.Admin)
                context.Result = new UnauthorizedResult();

            try
            {
                await next();
            }
            catch
            {
            }
        }
    }
}
