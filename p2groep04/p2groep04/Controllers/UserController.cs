using System.Collections.Generic;
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
        
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public ActionResult Index(User user)
        {
            Promotor promotor = (Promotor)userRepository.FindBy(user.Id); ;

            //Student student1 = new Student();

            //student1.FirstName = "Roy";
            //student1.LastName = "Hollanders";
            //student1.Email = "roy_9852@hotmail.com";
            //student1.Id = 4;
            
            //promotor.Students.Add(student1);
            IEnumerable<Student> studenten = promotor.Students;
            return View(studenten);
        }

        public ActionResult Detail(int id)
        {
            User user = userRepository.FindBy(id);
            return View(user);
        }




    }
}
