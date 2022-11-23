using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace ConnorWyatt.SPAApplication;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
  [HttpPost("login")]
  public async Task<IActionResult> LogIn()
  {
    var claims = new List<Claim>
    {
      new(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
      new(ClaimTypes.Name, "John Doe"),
    };

    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

    var principal = new ClaimsPrincipal(identity);

    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

    return Ok();
  }

  [HttpPost("logout")]
  public async Task<IActionResult> LogOut()
  {
    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

    return Ok();
  }
}
