using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConnorWyatt.APIApplication;

[Authorize]
[ApiController]
public class ResourceController : ControllerBase
{
  [HttpGet("resource")]
  public IActionResult GetResource()
  {
    return Ok(
      new
      {
        Message = "Hello, world!",
      });
  }
}
