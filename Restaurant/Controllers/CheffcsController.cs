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
    public class CheffcsController : ControllerBase
    {
        private readonly RestaurantDbContext _context;

        public CheffcsController(RestaurantDbContext context)
        {
            _context = context;
        }

        // GET: api/Cheffcs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cheffcs>>> Getcheffcs()
        {
            return await _context.cheffcs.ToListAsync();
        }

        // GET: api/Cheffcs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cheffcs>> GetCheffcs(int id)
        {
            var cheffcs = await _context.cheffcs.FindAsync(id);

            if (cheffcs == null)
            {
                return NotFound();
            }

            return cheffcs;
        }

        // PUT: api/Cheffcs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCheffcs(int id, Cheffcs cheffcs)
        {
            if (id != cheffcs.CheffcsId)
            {
                return BadRequest();
            }

            _context.Entry(cheffcs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheffcsExists(id))
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

        // POST: api/Cheffcs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cheffcs>> PostCheffcs(Cheffcs cheffcs)
        {
            _context.cheffcs.Add(cheffcs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCheffcs", new { id = cheffcs.CheffcsId }, cheffcs);
        }

        // DELETE: api/Cheffcs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCheffcs(int id)
        {
            var cheffcs = await _context.cheffcs.FindAsync(id);
            if (cheffcs == null)
            {
                return NotFound();
            }

            _context.cheffcs.Remove(cheffcs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CheffcsExists(int id)
        {
            return _context.cheffcs.Any(e => e.CheffcsId == id);
        }
    }
}
