using Microsoft.AspNetCore.Mvc;

namespace slx.auto.com.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        public IActionResult Get()
        {
            return Ok("ok");
        }
    }
}