using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //var test = new q2();
            //var input = new int[] {1,2,3,1 };
            //Console.WriteLine($"{ test.ContainsDuplicate(input) }"); 

            int[] a = {2,45,6,4,21,1,12,4,3,58,8,123,74,1526,986,125,8,2,1,96,21,6584,21,56,4,2 };

            //QuickSort.quickSort(a, 0, a.Length-1);
            HeapSort.heapSort(a);
            foreach (var i in a)
            {
                Console.Write(i+",");
            }

            Console.ReadKey();
        }
    }
}
