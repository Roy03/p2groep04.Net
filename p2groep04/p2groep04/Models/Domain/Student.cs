using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using p2groep04.Helpers;

namespace p2groep04.Models.Domain
{
    public class Student : User
    {
        public Promotor Promotor { get; set; }
        public Promotor CoPromotor { get; set; }

        public Dossier Dossier { get; set; }

        
        public void ChangeDeadline(DateTime newDeadline)
        {
            Dossier.Suggestion.Deadline = newDeadline;
        }

        public Feedback GetFeedbackListStudent()
        {
            foreach (var feedback in Dossier.Suggestion.Feedbacks)
            {
                if (feedback.Visable == true)
                    return feedback;
            }
        }

        
    }
}
