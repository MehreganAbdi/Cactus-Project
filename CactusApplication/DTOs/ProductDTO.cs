using CactusDomain.Data.Enums;

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
    }
}
