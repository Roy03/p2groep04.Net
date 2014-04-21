using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2groep04.Models.Domain
{
    public class Dossier
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public Suggestion Suggestion { get; set; }        
    }
}