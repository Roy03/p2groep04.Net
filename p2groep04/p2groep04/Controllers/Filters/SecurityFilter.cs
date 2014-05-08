using System.Web.Mvc;
using System.Web.Routing;
using p2groep04.Models.Domain;

namespace p2groep04.Controllers.Filters
{
    public class SecurityFilter : ActionFilterAttribute
    {
        private IUserRepository userRepository;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string userName = filterContext.HttpContext.User.Identity.Name;
            User user = userRepository.FindBy(userName);
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