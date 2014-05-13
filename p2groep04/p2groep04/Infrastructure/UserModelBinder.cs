using System.Web.Mvc;
using p2groep04.Models.Domain;

namespace p2groep04.Infrastructure
{
    public class UserModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext.HttpContext.User.Identity.IsAuthenticated)
            {
                IUserRepository repos =
                    (IUserRepository) DependencyResolver.Current.GetService(typeof (IUserRepository));
                return repos.FindByUsername(controllerContext.HttpContext.User.Identity.Name);
            }
            return null;
        }
    }
}