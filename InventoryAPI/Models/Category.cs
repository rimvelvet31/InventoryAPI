using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InventoryAPI.Models
{
    public class Category
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual ICollection<Product>? Products { get; set; }
    }
}
