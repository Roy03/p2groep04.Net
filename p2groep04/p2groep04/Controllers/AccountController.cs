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
        //
        // GET: /Account/Login
        private IUserRepository repos;
        public AccountController(IUserRepository repos)
        {
            this.repos = repos;
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

    }
}

