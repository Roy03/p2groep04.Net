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
    public class Promotor : User
    {
        public ICollection<Student> Students; 
        public String Company { get; set; }

        public List<String> GetFeedbackList(Student student)
        {
            return (from s in Students where s.FirstName == student.FirstName && s.LastName == student.LastName from suggestion in s.Suggestions from feedback in suggestion.Feedbacks select feedback.Inhoud).ToList();
        }
    }
}
