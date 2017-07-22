using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chat.Helpers
{
    /// <summary>
    /// Atrybut dla wymaganego klucza name sesji
    /// </summary>
    public class RequiredSessionNameAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(filterContext.HttpContext.Session!=null)
            {
                if(string.IsNullOrEmpty(filterContext.HttpContext.Session["name"] as string))
                {
                    filterContext.HttpContext.Response.Redirect("/Home/Index");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}