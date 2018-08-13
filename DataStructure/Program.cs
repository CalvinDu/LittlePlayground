using System;
using System.Collections.Generic;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            var x1 = new HashSet<int>();
            x1.Add(1);
            int x2 ;
            x1.TryGetValue(2, out x2);
            uint x3 = 0;
            ulong x4 = (ulong)(x3 - 1) + 1;
            var i = Math.Log(x4, 2);
            Console.WriteLine($"{x1.Contains(2)}, {x2}, {i}, {x4}");
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
