using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using p2groep04.Models.Domain;
using System.Web.Mvc;

namespace p2groep04.Controllers
{
    public class SuggestionController : Controller
    {
        private ISuggestionRepository suggestionRepository;
        private IUserRepository userRepository;

        public SuggestionController(ISuggestionRepository suggestionRep, IUserRepository userRep)
        {
            this.suggestionRepository = suggestionRep;
            this.userRepository = userRep;
        }


        public ActionResult Suggestion(int id)
        {
            IEnumerable<Suggestion> suggestions = suggestionRepository.FindByUser(id).ToList();
            return View(suggestions);
        }

    }
}
