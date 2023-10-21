using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusApplication.DTOs
{
    public class RegisterDTO
    {
        [Display(Name = "UserName")]
        [Required(ErrorMessage = "UserName is needed ")]
        public string UserName { get; set; }
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email is needed")]
        public string EmailAddress { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm The Password!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords Are Different")]
        public string ConfirmPassword { get; set; }
    }
}
