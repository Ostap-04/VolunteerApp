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
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            return Json(await _context.Category.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = await _context.Category.FirstOrDefaultAsync(c => c.Id == id);

            if (category == default) return NotFound();

            return Json(category);
        }

        [HttpPost]
        public async Task<ActionResult> AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                await _context.Category.AddAsync(category);

                await _context.SaveChangesAsync();

                return CreatedAtAction("AddCategory", new { id = category.Id }, category);
            }

            var message = GetModelValidationErrors();

            return BadRequest(message);
        }

        [HttpPut]
        public async Task<ActionResult<Category>> UpdateCategory(Category category)
        {
            if (category.Id == default || !CategoryExists(category.Id)) return NotFound();

            if (!ModelState.IsValid) return BadRequest(GetModelValidationErrors());

            _context.Category.Update(category);

            await _context.SaveChangesAsync();

            return Json(category);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var category = await _context.Category.FirstOrDefaultAsync(c => c.Id == id);

            if (category == default) return NotFound();

            _context.Category.Remove(category);

            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool CategoryExists(int id)
        {
            return _context.Category.Any(e => e.Id == id);
        }

        private IEnumerable<string> GetModelValidationErrors()
        {
           return ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage);
        }
    }
}
