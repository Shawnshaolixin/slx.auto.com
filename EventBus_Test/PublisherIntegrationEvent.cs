using slx.auto.com.eventbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBus_Test
{
    public class PublisherIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }

        public PublisherIntegrationEvent(int orderId) => OrderId = orderId;
    }
}
