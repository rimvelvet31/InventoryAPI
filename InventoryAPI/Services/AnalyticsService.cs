using InventoryAPI.DTO;
using InventoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Services
{
    public class AnalyticsService: IAnalyticsService
    {
        private readonly InventoryContext _context;

        public AnalyticsService(InventoryContext context)
        {
            _context = context;
        }

        // Analytics Methods
        public async Task<RevenueDto> GetTotalRevenueAsync()
        {
            var totalRevenue = await _context.Sales.SumAsync(s => s.TotalPrice);
            return new RevenueDto { TotalRevenue = totalRevenue };
        }

        public async Task<List<RevenueByItemDto>> GetRevenueByProductAsync()
        {
            return await _context.Sales
                .GroupBy(s => s.Product.Name)
                .Select(g => new RevenueByItemDto
                {
                    ItemName = g.Key,
                    Revenue = g.Sum(s => s.TotalPrice)
                })
                .ToListAsync();
        }

        public async Task<List<RevenueByItemDto>> GetRevenueByCategoryAsync()
        {
            return await _context.Sales
                .GroupBy(s => s.Product.Category.Name)
                .Select(g => new RevenueByItemDto
                {
                    ItemName = g.Key,
                    Revenue = g.Sum(s => s.TotalPrice)
                })
                .ToListAsync();
        }

        public async Task<ItemsSoldDto> GetTotalItemsSoldAsync()
        {
            var totalItemsSold = await _context.Sales.SumAsync(s => s.QuantitySold);
            return new ItemsSoldDto { TotalItemsSold = totalItemsSold };
        }

        public async Task<List<ItemsSoldByItemDto>> GetItemsSoldByProductAsync()
        {
            return await _context.Sales
                .GroupBy(s => s.Product.Name)
                .Select(g => new ItemsSoldByItemDto
                {
                    ItemName = g.Key,
                    QuantitySold = g.Sum(s => s.QuantitySold)
                })
                .ToListAsync();
        }

        public async Task<List<ItemsSoldByItemDto>> GetItemsSoldByCategoryAsync()
        {
            return await _context.Sales
                .GroupBy(s => s.Product.Category.Name)
                .Select(g => new ItemsSoldByItemDto
                {
                    ItemName = g.Key,
                    QuantitySold = g.Sum(s => s.QuantitySold)
                })
                .ToListAsync();
        }

        public async Task<List<InventoryLevelDto>> GetInventoryLevelsByProductAsync()
        {
            return await _context.Products
                .Select(p => new InventoryLevelDto
                {
                    Name = p.Name,
                    Quantity = p.Quantity
                })
                .ToListAsync();
        }

        public async Task<List<InventoryLevelDto>> GetInventoryLevelsByCategoryAsync()
        {
            return await _context.Categories
                .Select(c => new InventoryLevelDto
                {
                    Name = c.Name,
                    Quantity = c.Products.Sum(p => p.Quantity)
                })
                .ToListAsync();
        }
    }
}
