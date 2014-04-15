using System;
using System.Collections;
using System.Collections.Generic;
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
    }
}
