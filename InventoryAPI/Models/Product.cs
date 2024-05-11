using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.Models
{
    public class Product
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Category { get; set; }
        public required string ImgData { get; set; }

        [Range(0, double.MaxValue)]
        public required decimal UnitPrice { get; set; }

        [Range(0, int.MaxValue)]
        public required int Quantity { get; set; }
        
        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}
