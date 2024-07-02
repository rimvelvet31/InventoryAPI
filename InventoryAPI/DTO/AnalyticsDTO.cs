namespace InventoryAPI.DTO
{
    public class RevenueDto
    {
        public decimal TotalRevenue { get; set; }
    }

    // For revenues by product and category
    public class RevenueByItemDto
    {
        public string ItemName { get; set; }
        public decimal Revenue { get; set; }
    }

    public class ItemsSoldDto
    {
        public int TotalItemsSold { get; set; }
    }

    // For items sold by product and category
    public class ItemsSoldByItemDto
    {
        public string ItemName { get; set; }
        public int QuantitySold { get; set; }
    }

    // For inventory percentages by product and category
    public class InventoryLevelDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}   