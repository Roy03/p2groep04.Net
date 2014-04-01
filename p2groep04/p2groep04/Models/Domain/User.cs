using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace p2groep04.Models.Domain
{
    public abstract class User
    {
        //TPH is default

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

        public String PlainPassword { get; set; }

        [Column("last_login")]
        public DateTime LastLogin { get; set; }

        [Column("last_ip")]
        public String LastIp { get; set; }

        [Column("role")] 
        public int Role { get; set; }

        [Column("id")]
        public int Id {get; set;}

        public String SaltGenerator()
        {
            char[] saltComponents = ("ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789").ToCharArray();
            Random random = new Random();
            
            string salt = "";

            for (int i = 0; i <= 15; i++)
            {
                int randomComponent = random.Next(0, saltComponents.Length + 1);
                salt += saltComponents[randomComponent];
            }
            return salt;

        }
    }
}
