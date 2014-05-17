using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using p2groep04.Helpers;
using p2groep04.Models.DAL;
using p2groep04.Models.Domain;
using System.Web.Mvc;
using p2groep04.ViewModels;
using p2groep04.ViewModels.UserViewModels;

namespace p2groep04.Controllers
{
    [Authorize]
    public class SuggestionController : Controller
    {
        private readonly ISuggestionRepository _suggestionRepository;
        private readonly IUserRepository _userRepository;

        private readonly IResearchDomainRepository _researchDomainRepository;

        private string message;

        public SuggestionController(SuggestionRepository suggestionRepository, UserRepository userRepository,
             ResearchDomainRepository researchDomainRepository)
        {
            this._suggestionRepository = suggestionRepository;
            this._userRepository = userRepository;

            this._researchDomainRepository = researchDomainRepository;
        }

        //public ActionResult SubmitSuggestion()
        //{
        //    return View("SubmitSuggestion");
        //}

        public ViewResult Create(User user)
        {
           var student = (Student)user;
           return View();
        }

        public ActionResult Index(Student student)
        {
            if (student != null)
            {
                return View(_suggestionRepository.FindByUser(student.Id));
            }

            return View(_suggestionRepository.FindAll());
        }


        [HttpPost]
        public ActionResult Create(CreateViewModel model, User user, string btnSaveSend)
        {
            var student = (Student)user;

            if (ModelState.IsValid)
            {
                try
                {
                    var suggestion = new Suggestion
                    {
                        Title = model.Suggestion.Title,
                        Keywords = model.Suggestion.Keywords,
                        Context = model.Suggestion.Context,
                        Subject = model.Suggestion.Subject,
                        Goal = model.Suggestion.Goal,
                        ResearchQuestion = model.Suggestion.ResearchQuestion,
                        Motivation = model.Suggestion.Motivation,
                        References = model.Suggestion.References,
                        Student = student
                    };

                    var coPromotor = new CoPromotor
                    {
                        FirstName = model.CoPromotor.FirstName,
                        LastName = model.CoPromotor.LastName,
                        Email = model.CoPromotor.Email,
                        Company = model.CoPromotor.Organisation
                    };

                    //researchdomains
                   

                    if (btnSaveSend != null)
                    {
                        student.GiveInSuggestion(student, suggestion);
                        TempData["Success"] = "Uw voorstel werd aangemaakt en ingediend!";
                    }
                    else
                    {
                        TempData["Success"] = "Uw voorstel werd aangemaakt!";
                    }

                    student.CoPromotor = coPromotor;
                    student.Suggestions.Add(suggestion);
                    _userRepository.SaveChanges();
                    _suggestionRepository.SaveChanges();

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
        public ActionResult Edit(int id, EditViewModel model, User user, string btnSaveSend)
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
                    
                    suggestion.Student = student;

                    //researchdomains
                    

                    if (btnSaveSend != null)
                    {
                        student.GiveInSuggestion(student, suggestion);
                        TempData["Success"] = "Uw voorstel werd aangepast en ingediend!";

                    }
                    else
                    {
                        TempData["Success"] = "Uw voorstel werd aangepast!";
                    }

                    _userRepository.SaveChanges();
                    


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

                /*CoPromotor = new CoPromotorViewModel()
                {
                    FirstName = suggestion.Student.CoPromotor.FirstName,
                    LastName = suggestion.Student.CoPromotor.LastName,
                    Email = suggestion.Student.CoPromotor.Email,
                    Organisation = suggestion.Student.CoPromotor.Company
                }
                
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

        //public ActionResult Suggestions(int id)
        //{
        //    IEnumerable<Suggestion> suggestions = _suggestionRepository.FindByUser(id).ToList();
        //    return View();
        //}

        public ActionResult Evaluate(int id)
        {

            Suggestion suggestion = _suggestionRepository.FindBy(id);
            EvaluateViewModel suggestionViewModel = new EvaluateViewModel()
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
                }
            };

            return View(suggestionViewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Evaluate(int id, EvaluateViewModel model, User user, string btnSend,
            string btnAccept, string btnDecline, string btnBack)
        {
            Suggestion suggestion = _suggestionRepository.FindBy(id);

            var student = suggestion.Student;


            if (ModelState.IsValid)
            {
                try
                {
                    var promotor = (Promotor)user;



                    if (btnSend != null)
                    {
                        promotor.GiveFeedback(model.Suggestion.Feedback, student, suggestion, "");
                        TempData["Success"] = "Uw feedback is verzonden";
                    }

                    if (btnAccept != null)
                    {
                        promotor.GiveFeedback(model.Suggestion.Feedback, student, suggestion, btnAccept);
                        //notifieer stakeholder
                        TempData["Success"] = "Het voorstel is geaccepteerd";

                    }

                    if (btnDecline != null)
                    {
                        promotor.SuggestionDoesNotComply(student, suggestion);
                        //notifieer stakeholder
                        TempData["Success"] = "Het voorstel is afgekeurd";
                    }

                    _suggestionRepository.SaveChanges();

                    if (btnBack != null)
                    {
                        return RedirectToAction("Index", "Suggestion");
                    }

                }
                catch (ApplicationException e)
                {
                    ModelState.AddModelError("", e.Message); // shows in summary
                }
            }
            TempData["Error"] = "Uw verzoek is niet gelukt";
            return View();
        }

        public ActionResult Detail(int id, User user, DetailViewModel model)
        {
            Student student = (Student)user;

            Suggestion suggestion = _suggestionRepository.FindBy(id);
            DetailViewModel suggestionViewModel = new DetailViewModel()
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
                }
            };
            String feedback = suggestion.Student.GetFeedbackStudent();

            return View(suggestionViewModel);
        }

        public ActionResult Advice(int id)
        {

            Suggestion suggestion = _suggestionRepository.FindBy(id);
            AdviceViewModel suggestionViewModel = new AdviceViewModel()
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
                }
            };

            return View(suggestionViewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Advice(int id, AdviceViewModel model, User user, string btnGive)
        {
            Suggestion suggestion = _suggestionRepository.FindBy(id);

            var bpCoordinator = (BPCoordinator)user;

            if (btnGive != null)
            {
                bpCoordinator.GiveAdvice(suggestion, model.Suggestion.Advice);
                TempData["Success"] = "Het advies is verzonden";
                _suggestionRepository.SaveChanges();
            }

            return RedirectToAction("Index", "Suggestion");
        }

    }
}
