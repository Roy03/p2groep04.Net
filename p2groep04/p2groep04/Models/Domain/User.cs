using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace p2groep04.Models.Domain
{
    public abstract class User
    {
        //TPH is default
        public int Id { get; set; }

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Username { get; set; }
        public String Email { get; set; }

        public String Salt { get; set;}
        public String Password { get; set; }
        public DateTime LastLogin { get; set; }
        public String LastIp { get; set; }
        public DateTime LastPasswordChangedDate { get; set; }
        public DateTime CreationDate { get; set; }
        
        [NotMapped]
        public String PlainPassword { get; set; }

        public string SaltGenerator()
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
