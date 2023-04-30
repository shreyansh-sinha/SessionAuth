using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace SessionAuth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login()
        {
            // Authenticate user
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "John Doe")
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            // Sign in user
            await HttpContext.SignInAsync(principal);

            return Ok();
        }

        [Authorize]
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            // Sign out user
            await HttpContext.SignOutAsync();

            // Clear session cookie
            Response.Cookies.Delete("sessionCookie");

            return Ok();
        }
    }
}
