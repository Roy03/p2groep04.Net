using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using p2groep04.Models;
using p2groep04.Models.Domain;
using System.Web.Mvc;

namespace p2groep04.Controllers
{
    public class SuggestionController : Controller
    {
        private ISuggestionRepository suggestionRepository;
        private IUserRepository userRepository;

        public ActionResult SubmitSuggestion()
        {
            return View("SubmitSuggestion");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Submit(SuggestionModel model)
        {
            return View(model);
        }

        public ActionResult Suggestions(int id)
        {
            IEnumerable<Suggestion> suggestions = suggestionRepository.FindByUser(id).ToList();
            return View();
        }

    }
}
