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
    public class UserOrdersController : ControllerBase
    {
        private readonly RestaurantDbContext _context;

        public UserOrdersController(RestaurantDbContext context)
        {
            _context = context;
        }

        // GET: api/UserOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserOrder>>> Getuserorders()
        {
            return await _context.userorders.ToListAsync();
        }

        // GET: api/UserOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserOrder>> GetUserOrder(int id)
        {
            var userOrder = await _context.userorders.FindAsync(id);

            if (userOrder == null)
            {
                return NotFound();
            }

            return userOrder;
        }

        // PUT: api/UserOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserOrder(int id, UserOrder userOrder)
        {
            if (id != userOrder.UserOrderId)
            {
                return BadRequest();
            }

            _context.Entry(userOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserOrderExists(id))
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

        // POST: api/UserOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserOrder>> PostUserOrder(UserOrder userOrder)
        {
            _context.userorders.Add(userOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserOrder", new { id = userOrder.UserOrderId }, userOrder);
        }

        // DELETE: api/UserOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserOrder(int id)
        {
            var userOrder = await _context.userorders.FindAsync(id);
            if (userOrder == null)
            {
                return NotFound();
            }

            _context.userorders.Remove(userOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserOrderExists(int id)
        {
            return _context.userorders.Any(e => e.UserOrderId == id);
        }
    }
}
