using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Volunteer.Dto.Models;

namespace VolunteerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly VolunteerContext _context;

        public UserController(VolunteerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.User.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.User.FirstOrDefaultAsync( c => c.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("AddUser", new { id = user.Id}, user);
        }

        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!UserExists(user.Id))
            {
                return NotFound();
            }

            _context.User.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _context.User.FirstOrDefaultAsync(c => c.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
