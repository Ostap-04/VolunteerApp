using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volunteer.DataAccess;
using Volunteer.DataAccess.Handler;

namespace VolunteerApp.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    { 
        [HttpPost("{token}"), BasicAuthorization]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
