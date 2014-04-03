using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using p2groep04.Models.DAL;
using p2groep04.Models.Domain;
using WebMatrix.WebData;
using p2groep04.Models;
using IsolationLevel = System.Transactions.IsolationLevel;
using TransactionScope = System.Transactions.TransactionScope;

namespace p2groep04.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IUserRepository userRepository;

        public AccountController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            User user = userRepository.FindBy(1);
            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            {
                //return Redirect();
            }

            //ModelState.AddModelError("", "De login naam of wachtwoord die u heeft ingegeven is incorrect");
            return View(model);
        }

    }
}

