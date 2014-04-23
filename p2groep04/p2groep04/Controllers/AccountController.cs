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
using p2groep04.Helpers;
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
        private UserHelper userHelper;

        public AccountController(IUserRepository userRepository, UserHelper userHelper)
        {
            this.userRepository = userRepository;
            this.userHelper = userHelper;
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        /* Change password */
        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                string username = HttpContext.User.Identity.Name;
                try
                {
                    //verify old password
                    if (!userHelper.IsValidPassword(username, model.OldPlainPassword))
                    {
                        ModelState.AddModelError("OldPlainPassword", "Password is not correct");
                    }

                    //password same
                    if (!model.NewPlainPassword.Equals(model.ConfirmNewPlainPassword))
                    {
                        ModelState.AddModelError("ConfirmNewPlainPassword", "Both passwords do not match.");
                    }

                    String salt = userRepository.FindSaltByUsername(username);
                    string newPassHash = UserHelper.Encrypt(model.NewPlainPassword + salt);

                    bool success = userRepository.ChangePassword(username, newPassHash);

                    
                    if (!success)
                    {
                        //failed to change pass
                        TempData["Error"] = "Failed to change password";
                    }
                    else
                    {
                        TempData["Success"] = "Your password has been changed succesfully";
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return RedirectToAction("Dashboard","Home");
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
            if (ModelState.IsValid && userHelper.IsValidPassword(model.UserName, model.Password))
            {
                System.Diagnostics.Debug.WriteLine("Logged in!");
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                User user = userRepository.FindBy(model.UserName);
                /*if (user.LastPasswordChangedDate == user.CreationDate)
                {
                    return RedirectToAction("ChangePassword", "Account");
                }
                else
                {*/
                    return RedirectToAction("DashBoard", "Home");
                //}
                
            }

            ModelState.AddModelError("", "De login naam of wachtwoord die u heeft ingegeven is incorrect");
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View("ForgotPassword");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid && userHelper.IsValidEmail(model.Email))
            {
                System.Diagnostics.Debug.WriteLine("Email sent!");
                string password = userHelper.generatePassword(model.Email);
                string newPassHash = userHelper.generateSaltPassword(password, model.Email);
                string username = userRepository.FindByEmail(model.Email).Username;
                userRepository.ChangePassword(username, newPassHash);
                userHelper.sendMail(password, model.Email);
                return RedirectToAction("Login", "Account");
            }

            ModelState.AddModelError("", "De Email die u heeft ingegeven is incorrect");
            return View(model);
        }
    }
}

