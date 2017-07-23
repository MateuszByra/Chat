using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chat.Helpers
{
    /// <summary>
    /// Atrybut dla wymaganego klucza name cookie
    /// </summary>
    public class RequiredLoginNameAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(string.IsNullOrEmpty(filterContext.HttpContext.Request.Cookies.Get("name")?.Value))
            {
                filterContext.HttpContext.Response.Redirect("/Home/Index");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}