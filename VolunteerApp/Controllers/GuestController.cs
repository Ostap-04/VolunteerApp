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
        public async Task<ActionResult<IEnumerable<Guest>>> GetUsers()
        {
            return await _context.Guest.ToListAsync();
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
            //return CreatedAtAction("GetUser", user);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
