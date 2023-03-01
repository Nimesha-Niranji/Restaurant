using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooditemsController : ControllerBase
    {
        private readonly RestaurantDbContext _context;

        public FooditemsController(RestaurantDbContext context)
        {
            _context = context;
        }

        // GET: api/Fooditems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fooditem>>> Getfooditems()
        {
            return await _context.fooditems.ToListAsync();
        }

        // GET: api/Fooditems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fooditem>> GetFooditem(int id)
        {
            var fooditem = await _context.fooditems.FindAsync(id);

            if (fooditem == null)
            {
                return NotFound();
            }

            return fooditem;
        }

        // PUT: api/Fooditems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFooditem(int id, Fooditem fooditem)
        {
            if (id != fooditem.FooditemId)
            {
                return BadRequest();
            }

            _context.Entry(fooditem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FooditemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Fooditems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fooditem>> PostFooditem(Fooditem fooditem)
        {
            _context.fooditems.Add(fooditem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFooditem", new { id = fooditem.FooditemId }, fooditem);
        }

        // DELETE: api/Fooditems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFooditem(int id)
        {
            var fooditem = await _context.fooditems.FindAsync(id);
            if (fooditem == null)
            {
                return NotFound();
            }

            _context.fooditems.Remove(fooditem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FooditemExists(int id)
        {
            return _context.fooditems.Any(e => e.FooditemId == id);
        }
    }
}
