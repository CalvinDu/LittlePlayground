
using System;
using System.Text;

namespace RabbitMq
{
    class Program
    {
        static void Main(string[] args)
        {
            Send.Run();
            Receive.Run();
            Console.ReadKey();
        }
    }
}
