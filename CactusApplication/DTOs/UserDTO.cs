using CactusDomain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusApplication.DTOs
{
    public class UserDTO
    {
        public string UserId { get; set; }
        public string  Email { get; set; }
        public string UserName { get; set; }
        public int TotalCost { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public int? RCode { get; set; }
    }
}
