using Microsoft.AspNetCore.Mvc;

namespace RabbitTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        [Route(nameof(GetList))]
        public ActionResult<string> GetList()
        {
            return "订单列表";
        }
    }
}