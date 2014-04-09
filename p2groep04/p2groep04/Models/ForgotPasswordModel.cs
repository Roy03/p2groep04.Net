using System.ComponentModel.DataAnnotations;

namespace p2groep04.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}