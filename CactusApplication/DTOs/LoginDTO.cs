using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusApplication.DTOs
{
    public class LoginDTO
    {
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email is needed")]
        public string EmailAddress { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
