using CactusDomain.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusApplication.DTOs
{
    public class ProductDetailDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Cost { get; set; }
        public int Count { get; set; }
        public string Size { get; set; }
        public Brand Brand { get; set; }
        public string? AdditionalInfo { get; set; }
        public bool IsInFavorites { get; set; }
    }
}
