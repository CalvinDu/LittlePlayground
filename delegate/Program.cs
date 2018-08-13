using System;

namespace Delegate
{
    class Program
    {
        static void Main(string[] args)
        {

           var worker = new Worker();
            worker.DoWork(2);
            Console.ReadKey();
        }
    }
}
