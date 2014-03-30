using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace p2groep04.Models.Domain
{
    public class Suggestion
    {

        public String Titel { get; set; }

        public String[] Keywords { get; set; }

        public String Context { get; set; }

        public String Subject { get; set; }

        public String Goal { get; set; }

        public String ResearchQuestion { get; set; }

        public String Motivation { get; set; }

        public String[] References { get; set; }

        public int Id { get; set; }

        public SuggestionState CurrentState { get; set; }

        public void ToNewState()
        {
            CurrentState = new NewState(this.CurrentState);
        }

        public void ToSubmittedState()
        {
            CurrentState = new SubmittedState(this.CurrentState);
        }

        public void ToAdviceBPCState()
        {
            CurrentState = new AdviceBPCState(this.CurrentState);
        }

        public void ToApprovedState()
        {
            CurrentState = new ApprovedState(this.CurrentState);
        }

        public void ToApprovedWithRemarksState()
        {
            CurrentState = new ApprovedWithRemarksState(this.CurrentState);
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

        public ICollection<ResearchDomain> ResearchDomains
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
