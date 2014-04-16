using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace p2groep04.Models.Domain
{
    public class Student : User
    {
        public ICollection<Suggestion> Suggestions;
        public Promotor Promotor { get; set; }
        public Promotor CoPromotor { get; set; }

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

        public void ChangePromotor(Promotor newPromotor)
        {
            Promotor = newPromotor;
        }

        public List<String> GetFeedbackStudent()
        {
            return (from suggestion in Suggestions from feedback in suggestion.Feedbacks where feedback.Visable == true select feedback.Inhoud).ToList();
        }
    }
}
