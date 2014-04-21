using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using p2groep04.Models.Domain;

namespace p2groep04.Models.Domain
{
    public class ApprovedState : SuggestionState
    {
        public ApprovedState(Suggestion suggestion):base(suggestion)
        {
        }
    }
}
