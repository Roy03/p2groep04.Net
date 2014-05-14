using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using p2groep04.Helpers;

namespace p2groep04.Models.Domain
{
    public class BPCoordinator : User
    {
        public void GiveAdvice(Suggestion suggestion, String advice)
        {
            suggestion.AdviceBPC = advice;
            
            UserHelper.NotifyStakeholdersBpcHasGivenAdvice(suggestion.Student);
        }
    }
}
