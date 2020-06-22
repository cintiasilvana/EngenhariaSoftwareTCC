using System.Web.Mvc;
using TCC.Domain.Entities;

namespace TCC.Web.Filter
{
    public class CustomExceptionFilter : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];


            SessionConfig.SubMenu = new SubMenu
            {
                Controller = controllerName,
                Action = actionName
            };

        }
    }
}