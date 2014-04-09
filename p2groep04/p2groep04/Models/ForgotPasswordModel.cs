using System.ComponentModel.DataAnnotations;

namespace p2groep04.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}