using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRTest.handler
{
    public class TestEventHandler : IRequestHandler<TestEvent, string>
    {
        Task<string> IRequestHandler<TestEvent, string>.Handle(TestEvent request, CancellationToken cancellationToken)
        {
            Console.WriteLine($" id = {request.Id},");
            return Task.FromResult($"MsgID={request.Id},Pong");
        }
    }
}
