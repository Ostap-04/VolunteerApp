using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace VolunteerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NicknameController : Controller
    {
        private readonly VolunteerContext _context;

        public NicknameController(VolunteerContext context)
        {
            _context = context;
        }

        [HttpPost("{nickName}")]
        public bool Check(string nickName)
        {
            return _context.User.Any(n => n.NickName == nickName);
        }
    }
}
