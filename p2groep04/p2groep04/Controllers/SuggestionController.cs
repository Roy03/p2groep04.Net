using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using p2groep04.Models;
using p2groep04.Models.DAL;
using p2groep04.Models.Domain;
using System.Web.Mvc;

namespace p2groep04.Controllers
{
    public class SuggestionController : Controller
    {
        private readonly ISuggestionRepository _suggestionRepository;
        private readonly IUserRepository _userRepository;

        public SuggestionController(SuggestionRepository suggestionRepository, UserRepository userRepository)
        {
            this._suggestionRepository = suggestionRepository;
            this._userRepository = userRepository;
        }

        public ActionResult SubmitSuggestion()
        {
            return View("SubmitSuggestion");
        }

        public ViewResult Create()
        {
            return View();
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
            IEnumerable<Suggestion> suggestions = _suggestionRepository.FindByUser(id).ToList();
            return View();
        }

    }
}
