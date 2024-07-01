using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.Models
{
    public class Category
    {
        public long Id { get; set; }

        public required string Name { get; set; }
    }
}
