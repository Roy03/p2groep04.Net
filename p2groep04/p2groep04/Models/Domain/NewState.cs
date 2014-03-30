using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace p2groep04.Models.Domain
{
    public class NewState : SuggestionState
    {
        public NewState(Suggestion suggestion):base(suggestion)
        {
            
        }

        protected void Submit()
        {
            Suggestion.ToSubmittedState();
        }
    }
}
