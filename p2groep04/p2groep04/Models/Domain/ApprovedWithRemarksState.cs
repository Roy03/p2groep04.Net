using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using p2groep04.Models.Domain;

namespace p2groep04.Models.Domain
{
    public class ApprovedWithRemarksState : SuggestionState
    {
        public ApprovedWithRemarksState(Suggestion suggestion):base(suggestion)
        {
            
        }
    }
}
