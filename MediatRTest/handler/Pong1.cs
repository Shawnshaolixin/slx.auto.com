using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRTest.handler
{
    public class Pong1 : INotificationHandler<Ping>
    {
        Task INotificationHandler<Ping>.Handle(Ping notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Pong2 : INotificationHandler<Ping>
    {
        public Task Handle(Ping notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Pong 2");
            return Task.CompletedTask;
        }
    }
}
