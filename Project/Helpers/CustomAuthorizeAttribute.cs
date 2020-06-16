using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Project.Helpers
{
    public class CustomAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if(LoginUserSession.Current.IsAuthenticated == false)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "User", action = "Login" }));
            }
            else if(LoginUserSession.Current.IsAuthenticated == true && LoginUserSession.Current.IsAdministrator == false ) 
            {
                filterContext.Result = new ViewResult{ ViewName = "AccessDenied" };
            }
        }
    }
}