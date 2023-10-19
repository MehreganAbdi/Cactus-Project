using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusDomain.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string UserId { get; set; }
        public string FullAddress { get; set; } = "Not Defined";
        public string?  PostalCode { get; set; }

    }
}
