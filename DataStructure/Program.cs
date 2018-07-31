using System;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            test x;
            x = new test();
            x.x = 1;
            const int y = 1;
            Console.WriteLine($"{ x.x == 1 }, {x.x is y}");
            Console.ReadKey();
        }
    }

    public class test
    {
        public int? x { get; set; }
    }
}
