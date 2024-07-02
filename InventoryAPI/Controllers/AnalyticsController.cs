using InventoryAPI.DTO;
using InventoryAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly IAnalyticsService _analyticsService;

        public AnalyticsController(IAnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;
        }

        [HttpGet("total-revenue")]
        public async Task<ActionResult<RevenueDto>> GetTotalRevenue()
        {
            return await _analyticsService.GetTotalRevenueAsync();
        }

        [HttpGet("revenue-by-product")]
        public async Task<ActionResult<List<RevenueByItemDto>>> GetRevenueByProduct()
        {
            return await _analyticsService.GetRevenueByProductAsync();
        }

        [HttpGet("revenue-by-category")]
        public async Task<ActionResult<List<RevenueByItemDto>>> GetRevenueByCategory()
        {
            return await _analyticsService.GetRevenueByCategoryAsync();
        }

        [HttpGet("total-items-sold")]
        public async Task<ActionResult<ItemsSoldDto>> GetTotalItemsSold()
        {
            return await _analyticsService.GetTotalItemsSoldAsync();
        }

        [HttpGet("items-sold-product")]
        public async Task<ActionResult<List<ItemsSoldByItemDto>>> GetItemsSoldByProduct()
        {
            return await _analyticsService.GetItemsSoldByProductAsync();
        }

        [HttpGet("items-sold-category")]
        public async Task<ActionResult<List<ItemsSoldByItemDto>>> GetItemsSoldByCategory()
        {
            return await _analyticsService.GetItemsSoldByCategoryAsync();
        }

        [HttpGet("inventory-levels-product")]
        public async Task<ActionResult<List<InventoryLevelDto>>> GetInventoryLevelsByProduct()
        {
            return await _analyticsService.GetInventoryLevelsByProductAsync();
        }

        [HttpGet("inventory-levels-category")]
        public async Task<ActionResult<List<InventoryLevelDto>>> GetInventoryLevelsByCategory()
        {
            return await _analyticsService.GetInventoryLevelsByCategoryAsync();
        }
    }
}
