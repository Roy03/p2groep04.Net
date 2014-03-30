using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using p2groep04.Models.Domain;

namespace p2groep04.Models.Domain
{
    public class SubmittedState : SuggestionState
    {
        public SubmittedState(Suggestion suggestion):base(suggestion)
        {
            
        }

        protected void Reject(string feedback)
        {
            Suggestion.ToNewState();
        }

        protected void GiveFeedback(string feedback)
        {
            Suggestion.ToSubmittedState();
        }

        protected void RequestAdvice()
        {
            Suggestion.ToAdviceBPCState();
        }

        protected void ApproveWithRemarks(string feedback)
        {
            Suggestion.ToApprovedWithRemarksState();
        }

        protected void Approve()
        {
            Suggestion.ToApprovedState();
        }
    }
}
