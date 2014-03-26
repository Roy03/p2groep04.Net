using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace p2groep04
{
    public abstract class User
    {
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Username { get; set; }

        public String Email { get; set; }

        public String Salt { get; set; }

        public String Password { get; set; }

        public DateTime LastLogin { get; set; }

        public String LastIp { get; set; }

        public int Id
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
