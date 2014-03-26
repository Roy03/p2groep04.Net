using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace p2groep04
{
    public abstract class User
    {
        [Column("first_name")]
        public String FirstName { get; set; }

        [Column("last_name")]
        public String LastName { get; set; }

        [Column("username")]
        public String Username { get; set; }

        [Column("email")]
        public String Email { get; set; }

        [Column("salt")]
        public String Salt { get; set; }

        [Column("password")]
        public String Password { get; set; }

        [Column("last_login")]
        public DateTime LastLogin { get; set; }

        [Column("last_ip")]
        public String LastIp { get; set; }

        [Column("id")]
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
