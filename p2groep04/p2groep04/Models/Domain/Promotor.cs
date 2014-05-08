using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace p2groep04.Models.Domain
{
    public class Promotor : User
    {
        public ICollection<Student> Students = new Collection<Student>();
        public String Company { get; set; }

    
        public List<String> GetFeedbackList(Student student)
        {
            return (from s in Students where s.FirstName == student.FirstName && s.LastName == student.LastName from suggestion in s.Suggestions from feedback in suggestion.Feedbacks select feedback.Inhoud).ToList();
        }

        public void GiveFeedback(Feedback feedback, Student student, Suggestion suggestion)
        {
            foreach (var eenSuggestion in student.Suggestions)
            {
                if (eenSuggestion == suggestion)
                {
                    eenSuggestion.Feedbacks.Add(feedback);
                    eenSuggestion.ToApprovedState();
                }
            }

        }

        public void AskAdviseBpc(Student student, Suggestion suggestion)
        {
            foreach (var eenSuggestion in student.Suggestions)
            {
                if (eenSuggestion == suggestion)
                {
                    eenSuggestion.ToAdviceBpcState();
                }
            }
        }

        public void SuggestionDoesNotComply(Student student, Suggestion suggestion)
        {
            foreach (var eenSuggestion in student.Suggestions)
            {
                if (eenSuggestion == suggestion)
                {
                    eenSuggestion.ToNewState();
                }
            }
        }

        public void SuggestionAcceptedButWithRemark(Student student, Suggestion suggestion, Feedback remark)
        {
            foreach (var eenSuggestion in student.Suggestions)
            {
                if (eenSuggestion == suggestion)
                {
                    eenSuggestion.Feedbacks.Add(remark);
                    eenSuggestion.ToApprovedWithRemarksState();
                }
            }
        }

        public void SuggestionWithBuildingFeedback(Student student, Suggestion suggestion, Feedback feedback)
        {
            foreach (var eenSuggestion in student.Suggestions)
            {
                if (eenSuggestion == suggestion)
                {
                    eenSuggestion.Feedbacks.Add(feedback);
                }
            }
        }

        //    public List<Feedback> GetFeedbackList(Student student)
        //    {
        //        List<Feedback> feedbackList = new List<Feedback>();
        //        foreach (var feedback in student.Dossier.Suggestion.Feedbacks)
        //        {
        //            feedbackList.Add(feedback);
        //        }
        //        return feedbackList;
        //    }

        //    public void GiveFeedback(Feedback feedback, Student student, String state)
        //    {
        //        //Place the other feedbacks on invisable for the student
        //        foreach (var eenfeedback in student.Dossier.Suggestion.Feedbacks)
        //        {
        //            eenfeedback.Visable = false;
        //        }
        //        //Place newist feedback visable
        //        feedback.Visable = true;

        //        //Add the feedback
        //        student.Dossier.Suggestion.Feedbacks.Add(feedback);

        //        if (state == "Approve")
        //        {
        //            student.Dossier.Suggestion.ToApprovedState();
        //        }
        //        else
        //        {
        //            student.Dossier.Suggestion.ToApprovedWithRemarksState();
        //        }

        //    }

        //    public void AskAdviseBpc(Student student)
        //    {
        //        student.Dossier.Suggestion.ToAdviceBpcState();
        //    }

        //    public void SuggestionDoesNotComply(Student student)
        //    {
        //        student.Dossier.Suggestion.ToNewState();
        //    }

        //    public void SuggestionWithBuildingFeedback(Student student, Feedback feedback)
        //    {
        //          student.Dossier.Suggestion.Feedbacks.Add(feedback);  
        //    }
        //}
    }
}
