using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Web.UI.WebControls;
using p2groep04.Helpers;

namespace p2groep04.Models.Domain
{
    public class Promotor : User
    {
        public ICollection<Student> Students = new Collection<Student>();
        public String Company { get; set; }
        public List<User> users = new List<User>();
        private String message;
    
        public List<String> GetFeedbackList(Student student)
        {
            return (from s in Students where s.FirstName == student.FirstName && s.LastName == student.LastName from suggestion in s.Suggestions from feedback in suggestion.Feedbacks select feedback.Inhoud).ToList();
        }

        public void GiveFeedback(Feedback feedback, Student student, Suggestion suggestion, String state)
        {

            //Put all other feedbacks to not visable
            foreach (var f in suggestion.Feedbacks)
            {
                feedback.Visable = false;
            }
            //Add the new feedback
            suggestion.Feedbacks.Add(feedback);
            //add stakeholders
            users.Add(student);
            //message
            message = feedback.Inhoud;
            //Send notification
            UserHelper.NotifyUsers(users, message, "Feedback");

            //If state is approved the do this
            if (state == "Approve")
            {
                message = "Uw voorstel is geaccepteerd";
                suggestion.ToApprovedState();
                UserHelper.NotifyUsers(users, message, "Voorstel geaccepteerd");
            }

        }

        public void AskAdviseBpc(Student student, Suggestion suggestion)
        {
            //Set state 
            suggestion.ToAdviceBpcState();

            //INSERT NOTIFY STAKEHOLDERS HERE

        }

        public void SuggestionDoesNotComply(Student student, Suggestion suggestion)
        {
            //Put suggestion in new state
            suggestion.ToNewState();

            //add student to list for notifycation
            users.Add(student);
            //message
            message = "Uw voorstel is geweigerd";
            //send for notivication
            UserHelper.NotifyUsers(users, message, "Voorstel geweigerd");
        }

        public void SuggestionAcceptedButWithRemark(Student student, Suggestion suggestion, Feedback remark)
        {
            suggestion.Feedbacks.Add(remark);

            users.Add(student);
            message = "Uw voorstel is geaccepteerd maar er zijn opmerkingen";
            UserHelper.NotifyUsers(users, message, "Voorstel geaccepteerd met opmerkingen");
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
