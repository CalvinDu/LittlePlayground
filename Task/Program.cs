using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTest
{
    public class Program
    {
        public static int Counter { get; set; } = 0;
        public static readonly Object Lock = new Object();
        static void Main(string[] args)
        {
            var woker = new Worker();
            woker.DoJob();
            Console.ReadKey();
        }
    }

    public class Worker
    {
        public async void DoJob()
        {

            Task<int> work = Worker1();
            Console.WriteLine($"DoJob is working!");
            DoSomething("DoJob");

            var count2 =await work;

        }

        protected async Task<int> Worker1()
        {
           int count = 0;
           await Task.Run(() => {
               lock (Program.Lock)
               {
                   while (Program.Counter++ < 1000000)
                   {
                       count++;
                   }
               }
                Console.WriteLine($"worker1 did {count} works!");
            });

            return count;
        }

        void DoSomething(string name)
        {
            Console.WriteLine($"{name} is doing somthing");
            lock (Program.Lock)
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"I did something!{Program.Counter++}");
                }
            }

        }
    }
}
