using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace p2groep04
{
    public class Student : User
    {
        public Suggestion Suggestion { get; set; }

        public Jury Jury { get; set; }
    }
}
