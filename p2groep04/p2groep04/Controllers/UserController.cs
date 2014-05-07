using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2groep04.Models.DAL;
using p2groep04.Models.Domain;

namespace p2groep04.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        private IUserRepository userRepository;
        private StudentRepository studentRepository;

        public ActionResult Index(Promotor promotor)
        {
            IEnumerable<Student> studenten = promotor.Students;


            return View();
        }

    }
}
