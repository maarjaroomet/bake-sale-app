using BakeSale.Data;
using BakeSale.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BakeSale.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly BakeSaleDbContext _context;

        public ItemsController(BakeSaleDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Item>> CreateItem(Item newItem)
        {
            _context.Items.Add(newItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItems), new { id = newItem.Id }, newItem);
        }

        [HttpPost("update-quantities")]
        public IActionResult UpdateQuantities([FromBody] Dictionary<int, int> updatedQuantities)
        {
            foreach (var entry in updatedQuantities)
            {
                var item = _context.Items.Find(entry.Key);
                if (item != null)
                {
                    item.Quantity = entry.Value;
                }
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}