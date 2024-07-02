using InventoryAPI.DTO;

namespace InventoryAPI.Services
{
    public interface IAnalyticsService
    {
        Task<RevenueDto> GetTotalRevenueAsync();
        Task<List<RevenueByItemDto>> GetRevenueByProductAsync();
        Task<List<RevenueByItemDto>> GetRevenueByCategoryAsync();
        Task<ItemsSoldDto> GetTotalItemsSoldAsync();
        Task<List<ItemsSoldByItemDto>> GetItemsSoldByProductAsync();
        Task<List<ItemsSoldByItemDto>> GetItemsSoldByCategoryAsync();
        Task<List<InventoryLevelDto>> GetInventoryLevelsByProductAsync();
        Task<List<InventoryLevelDto>> GetInventoryLevelsByCategoryAsync();
    }
}
