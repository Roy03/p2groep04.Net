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

        private readonly SuggestionState _adviceBpcState;
        private readonly SuggestionState _approvedState;
        private readonly SuggestionState _approvedWithRemarksState;
        private readonly SuggestionState _submittedState;
        private readonly SuggestionState _newState;

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

        public Suggestion()
        {
            _adviceBpcState = new AdviceBPCState(this);
            _approvedState = new ApprovedState(this);
            _approvedWithRemarksState = new ApprovedWithRemarksState(this);
            _submittedState = new SubmittedState(this);
            _newState = new NewState(this);
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
