using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NodaTime;

namespace ConnorWyatt.SPAApplication;

[ApiController]
[Authorize]
[Route("api")]
public class ResourceController : ControllerBase
{
  [HttpGet("resource")]
  public IActionResult GetResource()
  {
    return Ok(new
    {
      Message = "This is a message from the API!",
      Timestamp = SystemClock.Instance.GetCurrentInstant(),
    });
  }
}
