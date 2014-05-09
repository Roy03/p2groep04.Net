using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2groep04.Models.Domain;

namespace p2groep04.Infrastructure
{
    public class StudentModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext.HttpContext.User.Identity.IsAuthenticated)
            {
                IUserRepository repos = (IUserRepository)DependencyResolver.Current.GetService(typeof(IUserRepository));
                User user = repos.FindByUsername(controllerContext.HttpContext.User.Identity.Name);
                if (user.GetType() == typeof (Student))
                {
                    return (Student) user;
                }
                return null;
            }
            return null;
        }
    }
}