using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Presentation
{
    public class AuthenticateAttribute : FilterAttribute, IAuthenticationFilter
    {

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (HttpContext.Current.Session["CurrentUserId"] != null)
            {
                return;
            }
            else
            {
                throw new HttpException(401, "Unauthorized Access");
                //throw new Exception("Unauthorized");
            }
        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            return;
        }
    }
}