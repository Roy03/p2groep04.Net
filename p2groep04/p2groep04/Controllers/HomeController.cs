using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2groep04.Models;


namespace p2groep04.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [HttpGet]
        public ViewResult LoginForm()
        {
            return View();
        }
        [HttpPost]
        public ViewResult LoginForm(LogInResponse guestResponse)
        {
            return View();
        }

        [HttpGet]
        public ViewResult ForgotPasswordForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult ForgotPasswordForm(LogInResponse logInResponse)
        {
            if (ModelState.IsValid)
            {
                //TODO: Email to the party organizer
                return View("Thanks", logInResponse);
            }
            else
            {
                //there is a validation error
                return View();
            }
        }
    }
}
