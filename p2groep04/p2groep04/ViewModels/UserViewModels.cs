using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace p2groep04.ViewModels.UserViewModels
{
    public class UserViewModel
    {
        [Display(Name = "Voornaam")]
        public String FirstName { get; set; }

        [Display(Name = "Naam")]
        public String LastName { get; set; }

        [Display(Name = "Username")]
        public String Username { get; set; }

        [Display(Name = "Email")]
        public String Email { get; set; }

        [Display(Name = "Laatst ingelogd")]
        public DateTime LastLogin { get; set; }

        [Display(Name = "Laatste IP")]
        public String LastIp { get; set; }

        [Display(Name = "Datum creatie")]
        public int CreationDate { get; set; }

        [Display(Name = "Datum paswoord gewijzigd")]
        public int LastPasswordChangedDate { get; set; }

        [Display(Name = "Rol")]
        public int Role { get; set; }

        [Display(Name = "ID")]
        public int Id { get; set; }
    }

    public class StudentViewModel : UserViewModel
    {
    
    }

    public class PromotorViewModel : UserViewModel
    {
        [Display(Name = "Organisatie")]
        public String Organisation { get; set; }
    }

}