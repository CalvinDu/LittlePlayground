using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace RabbitMq
{
    public static class Send
    {
        public static void Run()
        {
            var factory = new ConnectionFactory() { HostName = "localhost"};
            using (var con = factory.CreateConnection())
            {
                using (var channel = con.CreateModel())
                {
                    channel.QueueDeclare(queue: "hello_test", durable: false, exclusive: false, autoDelete: false, arguments: null);
                    var message = "hello test";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                        routingKey: "hello",
                        basicProperties: null,
                        body: body);
                    Console.WriteLine($"Sender sended : {message}");
                }
            }
        }
    }
}
