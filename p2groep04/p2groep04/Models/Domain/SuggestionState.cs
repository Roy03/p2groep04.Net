using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using p2groep04.Models.Domain;

namespace p2groep04.Models.Domain
{
    public abstract class SuggestionState
    {

        protected Suggestion Suggestion { get; set; }


        protected SuggestionState(Suggestion suggestion)
        {
            Suggestion = suggestion;
        }
    
        public void Submit()
        {
            throw new System.NotImplementedException();
        }

        public void Approve()
        {
            throw new System.NotImplementedException();
        }

        public void Approve(String feedback)
        {
            throw new System.NotImplementedException();
        }

        public void ApproveWithRemarks(string feedback)
        {
            throw new System.NotImplementedException();
        }

        public void GiveFeedback(string feedback)
        {
            throw new System.NotImplementedException();
        }

        public void Reject(string feedback)
        {
            throw new System.NotImplementedException();
        }

        public void RequestAdvice()
        {
            throw new System.NotImplementedException();
        }

        public void GiveAdvice()
        {
            throw new System.NotImplementedException();
        }
    }
}
