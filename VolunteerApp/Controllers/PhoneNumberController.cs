using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace VolunteerApp.Controllers
{
    public class PhoneNumberController : Controller
    {
        private readonly VolunteerContext _context;

        public PhoneNumberController(VolunteerContext context)
        {
            _context = context;
        }

        public bool Check(string number)
        {
            return _context.User.Any(p => p.Phone_Number == number);
        }
    }
}
