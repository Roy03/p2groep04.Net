using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using p2groep04.Helpers;
using p2groep04.Models.DAL;
using p2groep04.Models.Domain;
using System.Web.Mvc;
using p2groep04.ViewModels;

namespace p2groep04.Controllers
{
    [Authorize]
    public class SuggestionController : Controller
    {
        private readonly ISuggestionRepository _suggestionRepository;
        private readonly IUserRepository _userRepository;
        
        private readonly IResearchDomainRepository _researchDomainRepository;
        private List<User> stakeholdersList;
        private string message;

        public SuggestionController(SuggestionRepository suggestionRepository, UserRepository userRepository,
             ResearchDomainRepository researchDomainRepository)
        {
            this._suggestionRepository = suggestionRepository;
            this._userRepository = userRepository;
           
            this._researchDomainRepository = researchDomainRepository;
            stakeholdersList = new List<User>();
        }

        //public ActionResult SubmitSuggestion()
        //{
        //    return View("SubmitSuggestion");
        //}

        public ViewResult Create(User user)
        {
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
        public ActionResult Create(CreateViewModel model, User user, string buttonSave, string buttonSaveSend)
        {
            Student student = (Student)user;

            if (ModelState.IsValid)
            {
                try
                {
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
                        stakeholdersList.Add(student.Promotor);
                        message = "Student " + student.FirstName + " " + student.LastName +
                                  " heeft zijn voorstel ingediend";
                        UserHelper.NotifyUsers(stakeholdersList, message, "Voorstel ingediend");
                        TempData["Success"] = "Uw voorstel werd aangemaakt en ingediend!";
                    }
                    else
                    {
                        TempData["Success"] = "Uw voorstel werd aangemaakt!";
                    }

                    student.Suggestions.Add(suggestion);
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
                        stakeholdersList.Add(student.Promotor);
                        message = "Student " + student.FirstName + " " + student.LastName +
                                  " heeft zijn voorstel ingediend";
                        UserHelper.NotifyUsers(stakeholdersList, message, "Voorstel ingediend");

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

        //public ActionResult Suggestions(int id)
        //{
        //    IEnumerable<Suggestion> suggestions = _suggestionRepository.FindByUser(id).ToList();
        //    return View();
        //}

        public ActionResult Evaluate(int id)
        {
            Suggestion suggestion = _suggestionRepository.FindBy(id);
            return View(suggestion);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Evaluate(int id, EditViewModel model, User user, string buttonSendFeedback,
            string buttonApprove, string buttonDecline, string buttonBack)
        {
            Suggestion suggestion = _suggestionRepository.FindBy(id);

            var student = suggestion.Student;

            if (ModelState.IsValid)
            {
                try
                {
                    var promotor = (Promotor)user;
                    
                    _suggestionRepository.SaveChanges();

                    if (buttonSendFeedback != null)
                    {
                        //UserHelper.NotifyStakeholderFeedbackGiven();
                        TempData["Success"] = "Uw feedback is verzonden";
                    }

                    if (buttonApprove != null)
                    {
                        suggestion.ToApprovedState();
                        //notifieer stakeholder
                        TempData["Success"] = "Het voorstel is geaccepteerd";

                    }

                    if (buttonDecline != null)
                    {
                        suggestion.ToNewState();
                        //notifieer stakeholder
                        TempData["Success"] = "Het voorstel is afgekeurd";
                    }

                    if (buttonBack != null)
                    {
                        return RedirectToAction("Index", "Suggestion");
                    }



                }
                catch (ApplicationException e)
                {
                    ModelState.AddModelError("", e.Message); // shows in summary
                }
            }
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
        public ActionResult Advice(int id, AdviceViewModel model, User user, string buttonGiveAdvice)
        {
            Suggestion suggestion = _suggestionRepository.FindBy(id);

            var bpCoordinator = (BPCoordinator)user;
            
           
                bpCoordinator.GiveAdvice(suggestion, model.Suggestion.Advice);
                TempData["Success"] = "Het advies is verzonden";
                _suggestionRepository.SaveChanges();
                return RedirectToAction("Index", "Suggestion");
                


            return View();
        }

    }
}
