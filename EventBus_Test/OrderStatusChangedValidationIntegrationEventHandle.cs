using Microsoft.Extensions.Logging;
using slx.auto.com.eventbus;
using System.Threading.Tasks;

namespace EventBus_Test
{
    public class OrderStatusChangedValidationIntegrationEventHandle : IIntegrationEventHandler<PublisherIntegrationEvent>
    {
        private readonly ILogger<OrderStatusChangedValidationIntegrationEventHandle> _logger = null;
        public OrderStatusChangedValidationIntegrationEventHandle(ILogger<OrderStatusChangedValidationIntegrationEventHandle> logger)
        {
            _logger = logger;
        }
        public async Task Handle(PublisherIntegrationEvent @event)
        {
            _logger.LogError("收到MQ" + @event.OrderId);
        }
    }
}
