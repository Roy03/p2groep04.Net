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
using p2groep04.ViewModels;
using p2groep04.ViewModels.UserViewModels;

namespace p2groep04.Controllers
{
    public class SuggestionController : Controller
    {
        private readonly ISuggestionRepository _suggestionRepository;
        private readonly IUserRepository _userRepository;
        private readonly StudentRepository _studentRepository;

        public SuggestionController(SuggestionRepository suggestionRepository, UserRepository userRepository, StudentRepository studentRepository)
        {
            this._suggestionRepository = suggestionRepository;
            this._userRepository = userRepository;
            this._studentRepository = studentRepository;
        }

        public ActionResult SubmitSuggestion()
        {
            return View("SubmitSuggestion");
        }

        public ViewResult Create()
        {
            return View();
        }

        public ActionResult Index(Student student)
        {
            return View(_suggestionRepository.FindByUser(student.Id));
        }

        [HttpPost]
        public ActionResult Create(CreateViewModel model, User user, string buttonSave, string buttonSaveSend)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Student student = (Student) user;

                    Suggestion suggestion = new Suggestion();
                    suggestion.Title = model.Suggestion.Title;
                    suggestion.Keywords = model.Suggestion.Keywords;
                    suggestion.Context = model.Suggestion.Context;
                    suggestion.Subject = model.Suggestion.Subject;
                    suggestion.Goal = model.Suggestion.Goal;                    
                    suggestion.ResearchQuestion = model.Suggestion.ResearchQuestion;
                    suggestion.Motivation = model.Suggestion.Motivation;
                    suggestion.References = model.Suggestion.References;

                    //researchdomains
                    suggestion.Student = student;

                    if (buttonSaveSend != null)
                    {
                        suggestion.ToSubmittedState();
                        //notifieer stakeholders
                    }
                    
                    student.Suggestions.Add(suggestion);
                    _userRepository.SaveChanges();

                    if (buttonSaveSend != null)
                    {
                        TempData["Success"] = "Uw voorstel werd aangemaakt en ingediend!";
                    }
                    else
                    {
                        TempData["Success"] = "Uw voorstel werd aangemaakt!";    
                    }
                    

                    return RedirectToAction("DashBoard", "Home");
                }
                catch (ApplicationException e)
                {
                    ModelState.AddModelError("", e.Message); // shows in summary
                }
            }
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(int id, EditViewModel model, User user, string buttonSave, string buttonSaveSend)
        {
            Suggestion suggestion = _suggestionRepository.FindBy(id);

            if (ModelState.IsValid)
            {
                try
                {
                    Student student = (Student)user;

                    suggestion.Title = model.Suggestion.Title;
                    suggestion.Keywords = model.Suggestion.Keywords;
                    suggestion.Context = model.Suggestion.Context;
                    suggestion.Subject = model.Suggestion.Subject;
                    suggestion.Goal = model.Suggestion.Goal;
                    suggestion.ResearchQuestion = model.Suggestion.ResearchQuestion;
                    suggestion.Motivation = model.Suggestion.Motivation;
                    suggestion.References = model.Suggestion.References;

                    //researchdomains
                    suggestion.Student = student;

                    if (buttonSaveSend != null)
                    {
                        suggestion.ToSubmittedState();
                        //notifieer stakeholders
                    }

                    _suggestionRepository.SaveChanges();

                    if (buttonSaveSend != null)
                    {
                        TempData["Success"] = "Uw voorstel werd aangepast en ingediend!";
                    }
                    else
                    {
                        TempData["Success"] = "Uw voorstel werd aangepast!";
                    }


                    return RedirectToAction("DashBoard", "Home");
                }
                catch (ApplicationException e)
                {
                    ModelState.AddModelError("", e.Message); // shows in summary
                }
            }
            return View();
        }

        [Authorize]        
        public ActionResult Edit(int id)
        {
            Suggestion suggestion = _suggestionRepository.FindBy(id);
            EditViewModel suggestionViewModel = new EditViewModel()
            {
                Suggestion = new SuggestionViewModel()
                {
                    Id = suggestion.Id,
                    Context = suggestion.Context,
                    Goal = suggestion.Goal,
                    Keywords = suggestion.Keywords,
                    Motivation = suggestion.Motivation,
                    References = suggestion.References,
                    Subject = suggestion.Subject,
                    ResearchQuestion = suggestion.ResearchQuestion,
                    Title = suggestion.Title
                },
                /*
                 * HIER!
                 * 
                 * Student = new StudentViewModel()
                {
                    Id = suggestion.Student.Id,
                    Email = suggestion.Student.Email,
                    FirstName = suggestion.Student.FirstName,
                    LastName = suggestion.Student.LastName,
                    Username = suggestion.Student.Username
                }*/
            };

            return View(suggestionViewModel);
        }

        public ActionResult Suggestions(int id)
        {
            IEnumerable<Suggestion> suggestions = _suggestionRepository.FindByUser(id).ToList();
            return View();
        }
    }
}
