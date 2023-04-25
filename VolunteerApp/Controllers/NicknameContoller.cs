using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace VolunteerApp.Controllers
{
    public class NicknameController : Controller
    {
        private readonly VolunteerContext _context;

        public NicknameController(VolunteerContext context)
        {
            _context = context;
        }
        public bool Check(string nickName)
        {
            return _context.User.Any(n => n.NickName == nickName);
        }
    }
}
