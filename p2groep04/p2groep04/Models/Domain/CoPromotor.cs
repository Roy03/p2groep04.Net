using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2groep04.Models.Domain
{
    public class CoPromotor
    {
        public int Id { get; set; }

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Company { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}