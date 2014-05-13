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
                return repos.FindByUsername(htmlHelper.ViewContext.HttpContext.User.Identity.Name);
            }
            return null;
        }

      public static Student Student(this HtmlHelper htmlHelper)
        {
            User user = User(htmlHelper);
            if (user.GetType() == typeof(Student))
            {
                Student student = (Student) user;
                return student;
            }
            return null;
        }

    }
}