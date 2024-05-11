using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAPI.Models
{
    public class Sale
    {
        public long Id { get; set; }
        public required int QuantitySold { get; set; }
        public required decimal TotalPrice { get; set; }
        public required DateTime DateSold { get; set; } = DateTime.Now;

        public required long ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
