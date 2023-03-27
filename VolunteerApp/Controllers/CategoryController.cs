using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Volunteer.Dto.Models;

namespace VolunteerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly VolunteerContext _context;

        public CategoryController(VolunteerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _context.Category.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _context.Category.FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        [HttpPost]
        public async Task<ActionResult> AddCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Category.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("AddCategory", new { id = category.Id }, category);
        }
        [HttpPut]
        public async Task<ActionResult<Category>> UpdateCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!CategoryExists(category.Id))
            {
                return NotFound();
            }

            _context.Category.Update(category);
            await _context.SaveChangesAsync();

            return category;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var category = await _context.Category.FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool CategoryExists(int id)
        {
            return _context.Category.Any(e => e.Id == id);
        }
    }
}
