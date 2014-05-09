using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using p2groep04.Helpers;
using WebGrease.Css.Extensions;

namespace p2groep04.Models.Domain
{
    public class Suggestion
    {

        private readonly SuggestionState _adviceBpcState;
        private readonly SuggestionState _approvedState;
        private readonly SuggestionState _approvedWithRemarksState;
        private readonly SuggestionState _submittedState;
        private readonly SuggestionState _newState;

        public String Title { get; set; }
        public String[] Keywords { get; set; }
        public String Context { get; set; }
        public String AdviceBPC { get; set; }

        //de probleemstelling
        public String Subject { get; set; }

        //doelstelling
        public String Goal { get; set; }
        public String ResearchQuestion { get; set; }

        //plan van aanpak
        public String Motivation { get; set; }
        public String[] References { get; set; }
        public int Id { get; set; }
        public ICollection<ResearchDomain> ResearchDomains { get; set; }
        
        //Feedback
        public ICollection<Feedback> Feedbacks { get; set; }
        
        [NotMapped]
        public SuggestionState CurrentState { get; set; }
        
        public DateTime Deadline { get; set; }
        
        public int CurrentStateId { get; set; }

        public Student Student { get; set; }

        public Suggestion()
        {
            _adviceBpcState = new AdviceBPCState(this);
            _approvedState = new ApprovedState(this);
            _approvedWithRemarksState = new ApprovedWithRemarksState(this);
            _submittedState = new SubmittedState(this);
            _newState = new NewState(this);

            CurrentState = _newState;
        }

        public void ToNewState()
        {
            CurrentState = _newState;
        }

        public void ToSubmittedState()
        {
            CurrentState = _submittedState;
        }

        public void ToAdviceBpcState()
        {
            CurrentState = _adviceBpcState;
        }

        public void ToApprovedState()
        {
            CurrentState = _approvedState;
        }

        public void ToApprovedWithRemarksState()
        {
            CurrentState = _approvedWithRemarksState;
        }

        public void Submit()
        {
            CurrentState.Submit();
        }

        public void Reject(string feedback)
        {
            CurrentState.Reject(feedback);
        }

        public void GiveAdvice()
        {
            CurrentState.GiveAdvice();
        }

        public void RequestAdvice()
        {
            CurrentState.RequestAdvice();
        }

        public void GiveFeedback(string feedback)
        {
            CurrentState.GiveFeedback(feedback);
        }

        public void Approve()
        {
            CurrentState.Approve();
        }

        public void ApproveWithRemarks(string feedback)
        {
            CurrentState.ApproveWithRemarks(feedback);
        }

        public void ChangeResearchDomain(ResearchDomain newResearchDomain, ResearchDomain oldResearchDomain)
        {
            foreach (var researchDomain in ResearchDomains)
            {
                if (researchDomain.Name == oldResearchDomain.Name)
                {
                    researchDomain.Id = newResearchDomain.Id;
                    researchDomain.Name = newResearchDomain.Name;
                }
            }
            NotifyStakeHolderChangeResearchDomain(newResearchDomain, oldResearchDomain);

        }

        public void ChangePromotor(Promotor newPromotor)
        {
            Promotor oldPromotor = Student.Promotor;
            Student.Promotor = newPromotor;

            NotifyStakeHolderChangePromotor(oldPromotor, newPromotor);
        }

        public void NotifyStakeHolderChangeResearchDomain(ResearchDomain newResearchDomain,
            ResearchDomain oldResearchDomain)
        {
            List<User> stakeHoldersList = new List<User>();
            stakeHoldersList.Add(Student);
            stakeHoldersList.Add(Student.Promotor);

            string body = "Het onderzoeksdomein van " + Student.FirstName + " " + Student.LastName + " is gewijzigd van " + oldResearchDomain.Name +
            " naar " + newResearchDomain.Name + ".";
            const string subject = "Wijziging onderzoeksdomein";

            UserHelper.NotifyUsers(stakeHoldersList, body, subject);
        }

        public void NotifyStakeHolderChangePromotor(Promotor oldPromotor, Promotor newPromotor)
        {
            List<User> stakeHoldersList = new List<User>();
            stakeHoldersList.Add(Student);
            stakeHoldersList.Add(oldPromotor);
            stakeHoldersList.Add(newPromotor);

            string body = "De promotor van " + Student.FirstName + " " + Student.LastName + " is gewijzigd van " + oldPromotor.FirstName + " " + oldPromotor.LastName + 
            " naar " + newPromotor.FirstName + " " + newPromotor.LastName + ".";
            const string subject = "Wijziging promotor";

            UserHelper.NotifyUsers(stakeHoldersList, body, subject);
        }

    }
}
