using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using p2groep04.Models.DAL;
using p2groep04.Models.Domain;

namespace p2groep04.Controllers.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class SecurityFilter : ActionFilterAttribute
    {
        private IUserRepository _userRepository;
    
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        
        {
            string userName = filterContext.HttpContext.User.Identity.Name;
            User user = _userRepository.FindByUsername(userName);
            if (user.LastPasswordChangedDate == user.CreationDate)
            {
                filterContext.Result =
                    new RedirectToRouteResult(
                        new RouteValueDictionary(new {action = "ChangePassword", controller = "Account"}));
                base.OnActionExecuting(filterContext);
            }
        }
    }
}