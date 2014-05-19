using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Security;
using p2groep04.Helpers;
using p2groep04.Models.Domain;
using p2groep04.Models;

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


        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            string newPassword = model.NewPlainPassword;
            if (newPassword != null)
            {
                int conditionCount = userHelper.giveCondition(newPassword);
                string username = HttpContext.User.Identity.Name;

                if (ModelState.IsValid && userHelper.IsValidPassword(username, model.OldPlainPassword) &&
                    model.NewPlainPassword.Equals(model.ConfirmNewPlainPassword) && conditionCount >= 3 && !model.OldPlainPassword.Equals(model.NewPlainPassword))
                {
                    try
                    {
                        String salt = userRepository.FindSaltByUsername(username);
                        string newPassHash = UserHelper.Encrypt(model.NewPlainPassword + salt);
                        User user = userRepository.FindByUsername(username);
                        user.LastPasswordChangedDate = DateTime.Now;
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

                        return RedirectToAction("Dashboard", "Home");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                else
                {
                    if (!ModelState.IsValid)
                    {
                        //exceptie of lege view returne
                        return View(model);
                    }

                    //verify old password
                    if (!userHelper.IsValidPassword(username, model.OldPlainPassword))
                    {
                        ModelState.AddModelError("", "Uw huidig paswoord is incorrect.");
                    }
                    else
                    {

                        if (conditionCount < 3)
                        {
                            ModelState.AddModelError("",
                                "Uw nieuw wachtwoord moet een combinatie zijn van tenminste 3 van de volgende karakters: hoofdletters, kleine letters, getallen en overige symbolen.");
                        }
                        else
                        {
                            //password same
                            if (!model.NewPlainPassword.Equals(model.ConfirmNewPlainPassword))
                            {
                                ModelState.AddModelError("",
                                    "Uw bevestiging van het nieuwe wachtwoord is incorrect.");
                            }
                            else
                            {
                                if (model.OldPlainPassword.Equals(model.NewPlainPassword))
                                    ModelState.AddModelError("",
                                    "Uw nieuw wachtwoord mag niet hetzelfde zijn als het oude wachtwoord.");
                            }

                        }

                    }

                }
                return View(model);
            }
            

            return View(model);
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
                User user = userRepository.FindByUsername(model.UserName);

                if (user.LastPasswordChangedDate == user.CreationDate)
                {
                    return RedirectToAction("ChangePassword", "Account");
                }

                return RedirectToAction("DashBoard", "Home");

            }

            ModelState.AddModelError("", "Uw gebruikersnaam of wachtwoord is incorrect.");
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
            Match match = Regex.Match(model.Email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.hogent.be$");
            if (ModelState.IsValid && userHelper.IsValidEmail(model.Email) && match.Success == true)
            {
                System.Diagnostics.Debug.WriteLine("Email sent!");
                string password = userHelper.generatePassword(model.Email);
                string newPassHash = userHelper.generateSaltPassword(password, model.Email);
                string username = userRepository.FindByEmail(model.Email).Username;
                userRepository.ChangePassword(username, newPassHash);
                userHelper.sendMail(password, model.Email);
                return RedirectToAction("Login", "Account");
            }

            ModelState.AddModelError("", "Uw Email is incorrect.");
            return View(model);
        }
    }
}

