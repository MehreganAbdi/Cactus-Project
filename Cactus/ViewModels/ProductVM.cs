using CactusDomain.Data.Enums;

namespace Cactus.ViewModels
{
    public class ProductVM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Cost { get; set; }
        public Brand Brand { get; set; }
        public string? AdditionalInfo { get; set; }
    }
}
