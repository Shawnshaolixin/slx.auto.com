using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MediatRTest
{
    public class Service1 : IService1
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IContext _context;
        private readonly IService2 _service2;
        public Service1(ILogger<Service1> logger,
        IMediator mediator,
        IContext context)
        {
            _logger = logger;
            _mediator = mediator;
            _context = context;
            //_service2 = service2;
        }
        public async Task Method()
        {
            _context.CurrentUser = "test";

            await _mediator.Publish(new SomeEvent()
            {
                Name = "邵立新啊"
            });


            await Task.CompletedTask;
        }
    }
}
