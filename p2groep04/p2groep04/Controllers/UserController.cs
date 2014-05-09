using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2groep04.Models.DAL;
using p2groep04.Models.Domain;

namespace p2groep04.Controllers
{   [Authorize]
    public class UserController : Controller
    {
        //
        // GET: /User/

        private IUserRepository userRepository;
        private StudentRepository studentRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public ActionResult Index(User user)
        {
            Promotor promotor;

            Student student1 = new Student();

            student1.FirstName = "Roy";
            student1.LastName = "Hollanders";
            student1.Email = "roy_9852@hotmail.com";
            student1.Id = 1;

            promotor = (Promotor) userRepository.FindBy(user.Id);
            promotor.Students.Add(student1);
            IEnumerable<Student> studenten = promotor.Students;
            return View(studenten);
        }

    }
}
