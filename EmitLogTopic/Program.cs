using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmitLogTopic
{
    public class UserLocationDetails
    {
        public int LocationId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
    public class UserLocationUpdatedIntegrationEvent
    {
        public string UserId { get; set; }

        public List<UserLocationDetails> LocationList { get; set; }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "eshop_event_bus",
                                        type: "direct");
                UserLocationUpdatedIntegrationEvent model = new UserLocationUpdatedIntegrationEvent
                {
                    LocationList = new List<UserLocationDetails> {  new UserLocationDetails
                     {
                          Code="007",
                           Description="我是007",
                            LocationId=123
                     } },
                    UserId = "2555",
                };
                var routingKey = "UserLocationUpdatedIntegrationEvent";
                var message = JsonConvert.SerializeObject(model);
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "eshop_event_bus",
                                     routingKey: routingKey,
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent '{0}':'{1}'", routingKey, message);
                
            }
        }
    }
}
