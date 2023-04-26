using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Volunteer.Dto.Models;

namespace VolunteerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly VolunteerContext _context;

        public UserController(VolunteerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            return Json(await _context.User.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _context.User.FirstOrDefaultAsync( c => c.Id == id);

            if (user == default) return NotFound();

            return Json(user);
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                await _context.User.AddAsync(user);
                await _context.SaveChangesAsync();

                return Ok();
            }

            var message = GetModelValidationErrors();

            return BadRequest(message);
        }

        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser(User user)
        {
            if (user.Id == default || !UserExists(user.Id)) NotFound();

            if (!ModelState.IsValid)return BadRequest(GetModelValidationErrors());

            _context.User.Update(user);

            await _context.SaveChangesAsync();

            return Json(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _context.User.FirstOrDefaultAsync(c => c.Id == id);

            if (user == default) return NotFound();

            _context.User.Remove(user);

            await _context.SaveChangesAsync();

            return Ok();
        }
        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }

        private IEnumerable<string> GetModelValidationErrors()
        {
            return ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage);
        }
    }
}
