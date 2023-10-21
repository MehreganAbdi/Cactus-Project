using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusApplication.DTOs
{
    public class EmailVerificationDTO
    {
        public string UserId { get; set; }
        public string? Code { get; set; }
    }
}
