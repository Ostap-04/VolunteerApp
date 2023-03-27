using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Volunteer.Dto.Models;

namespace VolunteerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : Controller
    {
        private readonly VolunteerContext _context;

        public GuestController(VolunteerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guest>>> GetGuests()
        {
            return await _context.Guest.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Guest>> GetGuest(int id)
        {
            var guest = await _context.Guest.FirstOrDefaultAsync(c => c.Id == id);

            if (guest == null)
            {
                return NotFound();
            }

            return guest;
        }

        [HttpPost]
        public async Task<ActionResult> AddGuest(Guest guest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Guest.Add(guest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("AddGuest", new { id = guest.Id }, guest);
        }
        [HttpPut]
        public async Task<ActionResult<Guest>> UpdateGuest(Guest guest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!GuestExists(guest.Id))
            {
                return NotFound();
            }

            _context.Guest.Update(guest);
            await _context.SaveChangesAsync();

            return guest;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGuest(int id)
        {
            var guest = await _context.Guest.FirstOrDefaultAsync(c => c.Id == id);

            if (guest == null)
            {
                return NotFound();
            }

            _context.Guest.Remove(guest);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool GuestExists(int id)
        {
            return _context.Guest.Any(e => e.Id == id);
        }

    }
}
