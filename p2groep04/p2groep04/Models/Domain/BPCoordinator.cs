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
        public void GiveAdvice(Student student, Promotor promotor, Suggestion suggestion, String advice)
        {
            suggestion.AdviceBPC = advice;
            String message = advice;

       
            List<User> users = new List<User>();
            users.Add(student);
            users.Add(promotor);
            UserHelper.NotifyUsers(users, message, "Advies BPC");
        }
    }
}
