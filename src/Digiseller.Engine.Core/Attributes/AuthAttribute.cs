using Digiseller.Engine.Core.Areas.Dashboard.Models.Settings;
using Digiseller.Engine.Core.Helpers;
using Digiseller.Engine.Core.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Digiseller.Engine.Core.Attributes
{
    public class AuthAttribute : ActionFilterAttribute
    {
        private readonly IConfProvider _conf;
        public AuthAttribute(IConfProvider conf)
        {
            _conf = conf;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!_conf.Get<MainSettings>().Installed && filterContext.HttpContext.Request.Path == "/Dashboard/Home/Install")
                return;

            if (filterContext.HttpContext.Request.Path == "/Dashboard/Home/Login")
                return;

            if (!filterContext.HttpContext.Session.IsAuthorized())
            {
                filterContext.Result = new RedirectToActionResult("Login", "Home", new {Area = "Dashboard"});
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
