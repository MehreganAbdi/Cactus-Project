using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusDomain.Models
{
    public class User : IdentityUser 
    {
        public int TotalCost { get; set; }
        public int AddressId { get; set; }
        public int? RCode { get; set; } 

    }
}
