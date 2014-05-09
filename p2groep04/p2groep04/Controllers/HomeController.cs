using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2groep04.Controllers.Filters;
using p2groep04.Models;
using p2groep04.Models.DAL;
using p2groep04.Models.Domain;


namespace p2groep04.Controllers
{   [Authorize]
    public class HomeController : Controller
    {
        
        //
        // GET: /Home/
        //[SecurityFilter]
        public ViewResult Dashboard()
        {
            return View();
        }

    }
}
