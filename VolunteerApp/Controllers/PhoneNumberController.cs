using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace VolunteerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumberController : Controller
    {
        private readonly VolunteerContext _context;

        public PhoneNumberController(VolunteerContext context)
        {
            _context = context;
        }
        [HttpPost("{number}")]
        public bool Check(string number)
        {
            return _context.User.Any(p => p.Phone_Number == number);
        }
    }
}
