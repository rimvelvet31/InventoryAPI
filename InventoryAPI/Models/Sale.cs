using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAPI.Models
{
    public class Sale
    {
        public long Id { get; set; }

        [Required]
        public long ProductId { get; set; }

        [Range(0, int.MaxValue)]
        [Required]
        public int QuantitySold { get; set; }

        [Range(0, double.MaxValue)]
        public decimal TotalPrice { get; set; }

        public DateTime DateSold { get; set; } = DateTime.UtcNow;

        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }
    }
}
