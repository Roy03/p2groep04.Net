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
        public ICollection<Suggestion> Suggestions { get; set; }

        public Student()
        {
            Suggestions = new Collection<Suggestion>();
        }
        
        public void ChangeDeadline(DateTime newDeadline, DateTime oldDeadline)
        {
            foreach (var suggestion in Suggestions)
            {
                if (suggestion.Deadline == oldDeadline)
                {
                    suggestion.Deadline = newDeadline;
                }
            }
        }

        public Feedback GetFeedbackListStudent()
        {
            return (from suggestion in Suggestions from feedback in suggestion.Feedbacks where feedback.Visable == true select feedback).FirstOrDefault();
        }

        
    }
}
