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
        public virtual Promotor Promotor { get; set; }
        public virtual CoPromotor CoPromotor { get; set; }
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

        public String GetFeedbackStudent()
        {
            foreach (var suggestion in Suggestions)
            {
                if (suggestion.Feedbacks != null)
                {
                    foreach (var feedback in suggestion.Feedbacks)
                    {
                        if (feedback.Visable == true)
                        {
                            return feedback.Inhoud;
                        }
                    }
                }
                else
                {
                    return "Geen feedback";
                }

            }
            return null;
            //return (from suggestion in Suggestions from feedback in suggestion.Feedbacks where feedback.Visable == true select feedback).FirstOrDefault();
        }

        public void GiveInSuggestion(Student student, Suggestion suggestion)
        {
            suggestion.ToSubmittedState();
            UserHelper.NotifyStudentGivenSuggestion(student.Promotor);
        }

        
    }
}
