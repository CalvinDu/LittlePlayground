using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new q2();
            var input = new int[] {1,2,3,1 };
            Console.WriteLine($"{ test.ContainsDuplicate(input) }"); 
            Console.ReadKey();
        }
    }
}
