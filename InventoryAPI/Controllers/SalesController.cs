using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryAPI.Models;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly InventoryContext _context;

        public SalesController(InventoryContext context)
        {
            _context = context;
        }

        // GET: api/Sales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSales()
        {
            return await _context.Sales.ToListAsync();
        }

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSale(long id)
        {
            var sale = await _context.Sales.FindAsync(id);

            if (sale == null)
            {
                return NotFound();
            }

            return sale;
        }

        // PUT: api/Sales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutSale(long id, Sale sale)
        //{
        //    if (id != sale.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(sale).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SaleExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Sales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sale>> PostSale(Sale sale)
        {
            var product = await _context.Products.FindAsync(sale.ProductId);
            if (product == null)
            {
                return NotFound("Product not found.");
            }

            if (sale.QuantitySold > product.Quantity || sale.QuantitySold <= 0)
            {
                return BadRequest("Sale quantity invalid.");
            }

            sale.TotalPrice = sale.QuantitySold * product.UnitPrice;

            product.Quantity -= sale.QuantitySold;

            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSale", new { id = sale.Id }, sale);
        }

        // DELETE: api/Sales/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteSale(long id)
        //    {
        //        var sale = await _context.Sales.FindAsync(id);
        //        if (sale == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Sales.Remove(sale);
        //        await _context.SaveChangesAsync();

        //        return NoContent();
        //    }

        //    private bool SaleExists(long id)
        //    {
        //        return _context.Sales.Any(e => e.Id == id);
        //    }
    }
}
