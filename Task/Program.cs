using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskTest
{
    public class Program
    {
        public static int Counter { get; set; } = 0;
        public static readonly Object Lock = new Object();
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[10];
            Account acc = new Account(1000);
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(new ThreadStart(acc.DoTransactions));
                threads[i] = t;
            }
            for (int i = 0; i < 10; i++)
            {
                threads[i].Start();
            }

            //block main thread until all other threads have ran to completion.
            foreach (var t in threads)
                t.Join();

            Console.ReadKey();
        }
    }


    class Account
    {
        private Object thisLock = new Object();
        int balance;

        Random r = new Random();

        public Account(int initial)
        {
            balance = initial;
        }

        int Withdraw(int amount)
        {

            // This condition never is true unless the lock statement
            // is commented out.
            if (balance < 0)
            {
                throw new Exception("Negative Balance");
            }

            // Comment out the next line to see the effect of leaving out 
            // the lock keyword.
            lock (thisLock)
            {
                if (balance >= amount)
                {
                    Console.WriteLine("Balance before Withdrawal :  " + balance);
                    Console.WriteLine("Amount to Withdraw        : -" + amount);
                    balance = balance - amount;
                    Console.WriteLine("Balance after Withdrawal  :  " + balance);
                    return amount;
                }
                else
                {
                    return 0; // transaction rejected
                }
            }
        }

        public void DoTransactions()
        {
            for (int i = 0; i < 100; i++)
            {
                Withdraw(r.Next(1, 100));
            }
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
