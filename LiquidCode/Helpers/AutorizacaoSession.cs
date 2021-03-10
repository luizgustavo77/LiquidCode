using Commom.Dto.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace LiquidCode.Helpers
{
    public class AutorizacaoSession : ActionFilterAttribute
    { 
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            UserDto usuario = Session.GetObject<UserDto>("usuario");
            if (usuario == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new
                        {
                            controller = "Core",
                            action = "Login"
                        }));
            }
        }
    }
}
