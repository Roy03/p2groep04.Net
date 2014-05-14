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
        

        public DateTime CreatedOn { get; set; }
        

        public Boolean Visable { get; set; }

        public Suggestion Suggestion { get; set; }

        public Feedback(String inhoud)
        {
            Visable = true;
            CreatedOn = DateTime.Now;
            Inhoud = inhoud;
        }
        
    }
}
