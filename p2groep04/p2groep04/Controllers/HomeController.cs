using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2groep04.Controllers.Filters;
using p2groep04.Models;


namespace p2groep04.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [SecurityFilter]
        public ViewResult Dashboard()
        {
            return View();
        }

    }
}
