using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAPI.Models
{
    public class Sale
    {
        public long Id { get; set; }

        [Range(0, int.MaxValue)]
        public required int QuantitySold { get; set; }

        [ForeignKey("ProductId")]
        public required long ProductId { get; set; }

        public virtual Product? Product { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime DateSold { get; set; } = DateTime.Now;
    }
}
