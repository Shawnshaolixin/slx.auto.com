using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRTest
{
    public class SomeEventHandler : INotificationHandler<SomeEvent>, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly IService2 _service2;
        public SomeEventHandler()
        {

        }
        public void Dispose()
        {
            _logger.LogDebug("Handler disposed at :{0}", DateTime.Now);
        }

        async Task INotificationHandler<SomeEvent>.Handle(SomeEvent notification, CancellationToken cancellationToken)
        {
            await _service2.Method(notification.Name);
        }
    }
}
