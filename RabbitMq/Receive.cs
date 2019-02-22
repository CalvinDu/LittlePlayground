using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMq
{
    public static class Receive
    {
        public static void Run()
        {
            var factory = new ConnectionFactory() { HostName = "localhost"};
            using (var con = factory.CreateConnection())
            {
                using (var channel = con.CreateModel())
                {
                    channel.QueueDeclare(queue: "hello_test", durable: false, exclusive: false, autoDelete: false, arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine($"Receiver received : {message}");
                    };
                    channel.BasicConsume(queue: "hello_test", noAck: false, consumer: consumer);
                }
            }
            Console.ReadKey();
        }
    }
}
