using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace p2groep04.Models.Domain
{
    public class Suggestion
    {

        public String Titel { get; set; }

        public String[] Keywords { get; set; }

        public String Context { get; set; }

        public String Subject { get; set; }

        public String Goal { get; set; }

        public String ResearchQuestion { get; set; }

        public String Motivation { get; set; }

        public String[] References { get; set; }

        public int Id { get; set; }

        public ICollection<ResearchDomain> ResearchDomains
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
