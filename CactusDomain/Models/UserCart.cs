using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusDomain.Models
{
    public class UserCart
    {
        [Key]
        public int CartItemId { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
    }
}
