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
        public ICollection<Student> Students;
        public List<User> users;
        private String message;

        public Promotor()
        {
            Students = new Collection<Student>();
            users = new List<User>();
        }

        public List<String> GetFeedbackList(Student student)
        {
            return (from s in Students where s.FirstName == student.FirstName && s.LastName == student.LastName from suggestion in s.Suggestions from feedback in suggestion.Feedbacks select feedback.Inhoud).ToList();
        }

        public void GiveFeedback(String feedback, Student student, Suggestion suggestion, String state)
        {

            //Put all other feedbacks to not visable
            foreach (var f in suggestion.Feedbacks)
            {
                f.Visable = false;
            }
            //Add the new feedback
            suggestion.Feedbacks.Add(new Feedback(feedback));
            
            //Send notification
            UserHelper.NotifyStakeholderFeedbackGiven(student);

            //If state is approved the do this
            if (state == "Approve")
            {
                suggestion.ToApprovedWithRemarksState();
                UserHelper.NotifyStakeholderSuggestionAcceptedWithRemarks(student);
            }

        }

        public void AskAdviseBpc(Student student, Suggestion suggestion)
        {
            //Set state 
            suggestion.ToAdviceBpcState();
            BPCoordinator bpc = new BPCoordinator();
            //INSERT NOTIFY STAKEHOLDERS HERE
            UserHelper.NotifyStakeholderAdviceBpcNeeded(bpc);
            

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
            UserHelper.NotifyStakeholderSuggestionDeclined(student);
        }

        public void SuggestionAccepted(Student student, Suggestion suggestion)
        {
            suggestion.ToApprovedState();
            UserHelper.NotifyStakeholderSuggestionAccepted(student);
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
