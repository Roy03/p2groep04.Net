﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
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
                return repos.FindBy(controllerContext.HttpContext.User.Identity.Name);
            }
            return null;
        }
    }
}