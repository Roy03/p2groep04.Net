using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2groep04.Models.Domain;

namespace p2groep04.Helpers
{
    public static class UserExtensions
    {
        public static User User(this HtmlHelper htmlHelper)
        {
            var identity = htmlHelper.ViewContext.HttpContext.User.Identity;
            if (identity.IsAuthenticated)
            {
                IUserRepository repos = (IUserRepository)DependencyResolver.Current.GetService(typeof(IUserRepository));
                return repos.FindBy(htmlHelper.ViewContext.HttpContext.User.Identity.Name);
            }
            return null;
        }
    }
}