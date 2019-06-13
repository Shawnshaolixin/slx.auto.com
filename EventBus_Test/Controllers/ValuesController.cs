using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using slx.auto.com.eventbus;
using System.Collections.Generic;

namespace EventBus_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IEventBus _eventBus;
        private readonly ILogger<ValuesController> _logger = null;

        public ValuesController(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var @event = new PublisherIntegrationEvent(5);
            _eventBus.Publish(@event);
            _logger.LogError("发送MQ成功！");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
