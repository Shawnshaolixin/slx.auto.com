
using RabbitMQ.Client;
using System;

namespace slx.auto.com.eventbus.EventBusRabbitMQ
{
    public interface IRabbitMQPersistentConnection
       : IDisposable
    {
        bool IsConnected { get; }

        bool TryConnect();

        IModel CreateModel();
    }
}
