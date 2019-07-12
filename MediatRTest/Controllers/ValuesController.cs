using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediatRTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IMediator mediator;
        public ValuesController(IMediator mediator)
        {
           this. mediator = mediator;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {

            //   await mediator.Publish(new Ping());
            //   await mediator.Publish(new SomeEvent("邵立新"));
            await mediator.Send(new TestEvent(5));
            return "ok";
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
