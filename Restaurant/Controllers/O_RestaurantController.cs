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
    public class O_RestaurantController : ControllerBase
    {
        private readonly RestaurantDbContext _context;

        public O_RestaurantController(RestaurantDbContext context)
        {
            _context = context;
        }

        // GET: api/O_Restaurant
        [HttpGet]
        public async Task<ActionResult<IEnumerable<O_Restaurant>>> Getrestaurants()
        {
            return await _context.restaurants.ToListAsync();
        }

        // GET: api/O_Restaurant/5
        [HttpGet("{id}")]
        public async Task<ActionResult<O_Restaurant>> GetO_Restaurant(int id)
        {
            var o_Restaurant = await _context.restaurants.FindAsync(id);

            if (o_Restaurant == null)
            {
                return NotFound();
            }

            return o_Restaurant;
        }

        // PUT: api/O_Restaurant/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutO_Restaurant(int id, O_Restaurant o_Restaurant)
        {
            if (id != o_Restaurant.O_RestaurantId)
            {
                return BadRequest();
            }

            _context.Entry(o_Restaurant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!O_RestaurantExists(id))
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

        // POST: api/O_Restaurant
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<O_Restaurant>> PostO_Restaurant(O_Restaurant o_Restaurant)
        {
            _context.restaurants.Add(o_Restaurant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetO_Restaurant", new { id = o_Restaurant.O_RestaurantId }, o_Restaurant);
        }

        // DELETE: api/O_Restaurant/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteO_Restaurant(int id)
        {
            var o_Restaurant = await _context.restaurants.FindAsync(id);
            if (o_Restaurant == null)
            {
                return NotFound();
            }

            _context.restaurants.Remove(o_Restaurant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool O_RestaurantExists(int id)
        {
            return _context.restaurants.Any(e => e.O_RestaurantId == id);
        }
    }
}
