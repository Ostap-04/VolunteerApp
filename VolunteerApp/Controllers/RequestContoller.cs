using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Volunteer.Dto.Models;

namespace VolunteerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : Controller
    {
        private readonly VolunteerContext _context;

        public RequestController(VolunteerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequests()
        {
            return await _context.Request.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(int id)
        {
            var request = await _context.Request.FirstOrDefaultAsync(c => c.Id == id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }

        [HttpPost]
        public async Task<ActionResult> AddRequest(Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Request.Add(request);
            await _context.SaveChangesAsync();

            return CreatedAtAction("AddRequest", new { id = request.Id }, request);
        }
        [HttpPut]
        public async Task<ActionResult<Request>> UpdateRequest(Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!RequestExists(request.Id))
            {
                return NotFound();
            }

            _context.Request.Update(request);
            await _context.SaveChangesAsync();

            return request;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRequest(int id)
        {
            var request = await _context.Request.FirstOrDefaultAsync(c => c.Id == id);

            if (request == null)
            {
                return NotFound();
            }

            _context.Request.Remove(request);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool RequestExists(int id)
        {
            return _context.Request.Any(e => e.Id == id);
        }
    }
}
