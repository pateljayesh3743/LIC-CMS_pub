using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LIC_CMS.Models;

namespace LIC_CMS.Controllers
{
    public class AuthoriseAttribute:System.Web.Mvc.AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var array=Roles.Split(',');
            return array.Contains(SessionWrapper.RoleName);
        }
        protected override void HandleUnauthorizedRequest(System.Web.Mvc.AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Redirect("~/Login/Login");
        }

    }
}