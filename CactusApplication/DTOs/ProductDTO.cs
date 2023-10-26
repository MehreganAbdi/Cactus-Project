using CactusDomain.Data.Enums;
using Microsoft.AspNetCore.Http;

namespace CactusApplication.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Cost { get; set; }
        public int Count { get; set; }
        public string Size { get; set; }
        public Brand Brand { get; set; }
        public string? AdditionalInfo { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImageUri { get; set; }
    }
}
