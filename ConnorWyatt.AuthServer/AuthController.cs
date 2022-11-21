using System.Security.Claims;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;

namespace ConnorWyatt.AuthServer;

[ApiController]
public class AuthController : ControllerBase
{
  [HttpPost("connect/token")]
  public IActionResult RequestToken()
  {
    var request = HttpContext.GetOpenIddictServerRequest() ??
      throw new InvalidOperationException("The OpenID Connect request cannot be retrieved.");

    if (!request.IsClientCredentialsGrantType())
    {
      throw new InvalidOperationException("The specified grant type is not supported.");
    }

    var identity = new ClaimsIdentity(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

    identity.AddClaim(OpenIddictConstants.Claims.Subject, request.ClientId ?? throw new InvalidOperationException());

    var claimsPrincipal = new ClaimsPrincipal(identity);

    claimsPrincipal.SetScopes(request.GetScopes());

    return SignIn(claimsPrincipal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
  }
}
