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
        public async Task<ActionResult<IEnumerable<Guest>>> GetAllGuests()
        {
            return Json(await _context.Guest.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Guest>> GetGuestById(int id)
        {
            var guest = await _context.Guest.FirstOrDefaultAsync(c => c.Id == id);

            if (guest == default) return NotFound();

            return Json(guest);
        }

        [HttpPost]
        public async Task<ActionResult> AddGuest(Guest guest)
        {
            if (ModelState.IsValid)
            {
                await _context.Guest.AddAsync(guest);

                await _context.SaveChangesAsync();

                return Ok();
            }
            var message = GetModelValidationErrors();

            return BadRequest(message);

        }

        [HttpPut]
        public async Task<ActionResult<Guest>> UpdateGuest(Guest guest)
        {
            if (guest.Id == default || !GuestExists(guest.Id)) return NotFound();
            
            if (!ModelState.IsValid) return BadRequest();

            _context.Guest.Update(guest);

            await _context.SaveChangesAsync();

            return Json(guest);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGuest(int id)
        {
            var guest = await _context.Guest.FirstOrDefaultAsync(c => c.Id == id);

            if (guest == default) return NotFound();

            _context.Guest.Remove(guest);

            await _context.SaveChangesAsync();

            return Ok();
        }
        private bool GuestExists(int id)
        {
            return _context.Guest.Any(e => e.Id == id);
        }
        private IEnumerable<string> GetModelValidationErrors()
        {
            return ModelState.Values
                 .SelectMany(v => v.Errors)
                 .Select(e => e.ErrorMessage);
        }
    }
}
