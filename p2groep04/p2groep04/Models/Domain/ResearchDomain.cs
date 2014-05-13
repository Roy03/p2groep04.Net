using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace p2groep04.Models.Domain
{
    public class ResearchDomain
    {
        public int Id { get; set; }

        public String Name {get;set;}

        public ICollection<Suggestion> Suggestions { get; set; }
    }
}
