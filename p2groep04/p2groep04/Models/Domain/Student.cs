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


        public void ChangeDeadline(DateTime newDeadline)
        {
            Suggestions.Select(s =>
            {
                s.Deadline = newDeadline;
                return s;
            });
        }

    }
}
