using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using p2groep04.Models.Domain;

namespace p2groep04.Models.Domain
{
    public class AdviceBPCState : SuggestionState
    {
        public AdviceBPCState(Suggestion suggestion) : base(suggestion)
        {
            
        }

        protected void GiveAdvice()
        {
            Suggestion.ToSubmittedState();
        }
    }
}
