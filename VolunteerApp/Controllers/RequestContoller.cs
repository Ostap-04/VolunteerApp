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
        public async Task<ActionResult<IEnumerable<Request>>> GetAllRequests()
        {
            return Json(await _context.Request.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequestById(int id)
        {
            var request = await _context.Request.FirstOrDefaultAsync(c => c.Id == id);

            if (request == default) return NotFound();

            return Json(request);
        }

        [HttpPost]
        public async Task<ActionResult> AddRequest(Request request)
        {
            if (ModelState.IsValid)
            {
                await _context.Request.AddAsync(request);
                await _context.SaveChangesAsync();

                return Ok();
            }
            var message = GetModelValidationErrors();

            return BadRequest(message);
        }

        [HttpPut]
        public async Task<ActionResult<Request>> UpdateRequest(Request request)
        {
            if (request.Id == default || !RequestExists(request.Id)) return NotFound();

            if (!ModelState.IsValid) return BadRequest(GetModelValidationErrors());

            _context.Request.Update(request);

            await _context.SaveChangesAsync();

            return Json(request);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRequest(int id)
        {
            var request = await _context.Request.FirstOrDefaultAsync(c => c.Id == id);

            if (request == default) NotFound();

            _context.Request.Remove(request);
            await _context.SaveChangesAsync();

            return Ok();
        }
        private bool RequestExists(int id)
        {
            return _context.Request.Any(e => e.Id == id);
        }
        private IEnumerable<string> GetModelValidationErrors()
        {
            return ModelState.Values
                 .SelectMany(v => v.Errors)
                 .Select(e => e.ErrorMessage);
        }
    }
}
