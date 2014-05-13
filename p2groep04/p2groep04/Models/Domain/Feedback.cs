using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using p2groep04.Models.Domain;

namespace p2groep04
{
    public class Feedback
    {
        public int Id { get; set; }
   

        public String Inhoud { get; set; }
        

        public DateTime Created_On { get; set; }
        

        public Boolean Visable { get; set; }

        public Suggestion Suggestion { get; set; }

        public Feedback()
        {
            Visable = true;
            Created_On = DateTime.Now;
        }
        
    }
}
