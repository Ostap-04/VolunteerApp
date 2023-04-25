using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using VolunteerApp.Helpers;
using VolunteerApp.Services;

namespace VolunteerApp.Controllers
{
    public class GoogleOAuthController : Controller
    {
        public IActionResult RedirectOnOAuthServer()
        {
            var scope = "https://www.googleapis.com/auth/cloud-platform.read-only";
            var redirectUrl = "https://localhost:7263/GoogleOAuth/Code";

            var codeVerifier = Guid.NewGuid().ToString();

            HttpContext.Session.SetString("codeVerifier", codeVerifier);

            var codeChallenge = Sha256Helper.ComputeHash(codeVerifier);

            var url = GoogleOAuthService.GenerateOAuthREquestUrl(scope, redirectUrl, codeChallenge);
            return Redirect(url);
        }
        public async Task <IActionResult> CodeAsync(string code)
        {
            string codeVerifier = HttpContext.Session.GetString("codeVerifier");
            var redirectUrl = "https://localhost:7263/GoogleOAuth/Code";

            var tokenResult = await GoogleOAuthService.ExchangeCodeOnTokenAsync(code, codeVerifier, redirectUrl);

            //Wait 3600 sec

            var refreshedTokenResult = await GoogleOAuthService.RefreshTokenAsync(tokenResult.RefreshToken);

            return Ok();
        }
    }
}
