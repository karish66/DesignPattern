using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation
{
    public class AuthorizationAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if ((string)HttpContext.Current.Session["Role"] == "Admin")
            {
                return;
            }
            else
            {
                throw new HttpException(401, "Unauthorized Access");
            }
        }
    }
}