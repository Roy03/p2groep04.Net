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
        public ICollection<Suggestion> Suggestions { get; set; }
        public Promotor Promotor { get; set; }
        public Promotor CoPromotor { get; set; }

        public Student() : base()
        {
            Suggestions = new List<Suggestion>();
        }

        public void ChangeDeadline(DateTime newDeadline, DateTime oldDateTime)
        {
            foreach (var suggestion in Suggestions)
            {
                if (suggestion.Deadline == newDeadline)
                {
                    suggestion.Deadline = oldDateTime;
                }
            }
        }

        public List<String> GetFeedbackListStudent()
        {
            return (from suggestion in Suggestions from feedback in suggestion.Feedbacks where feedback.Visable == true select feedback.Inhoud).ToList();
        }

        
    }
}
