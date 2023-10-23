using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusApplication.DTOs
{
    public class CartDTO
    {
        public int CartItemId { get; set; }
 
        public int ProductId { get; set; }
 
        public string UserId { get; set; }
        public ProductDetailDTO? Product { get; set; }
    }
}
