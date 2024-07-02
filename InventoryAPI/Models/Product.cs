using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InventoryAPI.Models
{
    public class Product
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public long CategoryId { get; set; }

        [Required]
        public string Img { get; set; } = string.Empty;

        [Range(0, double.MaxValue)]
        [Required]
        public decimal UnitPrice { get; set; }

        [Range(0, int.MaxValue)]
        [Required]
        public int Quantity { get; set; }
        
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }

        [JsonIgnore]
        public virtual ICollection<Sale>? Sales { get; set; }
    }
}
