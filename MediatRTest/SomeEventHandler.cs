using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRTest
{
    public class SomeEventHandler : INotificationHandler<SomeEvent>, IDisposable
    {
        private ILogger _logger;
        private IServiceProvider _serviceProvider;
        private IService2 _service2;
        public SomeEventHandler(IService2 service2, ILogger logger, IServiceProvider serviceProvider)
        {
            this._service2 = service2;
            _logger = logger;
            _serviceProvider = serviceProvider;

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
