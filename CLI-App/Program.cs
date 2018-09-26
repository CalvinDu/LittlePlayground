using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI_App
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No Argument Detected!");
            }
            else
            {
                Console.WriteLine($"{args.Length} Arguments Detected.");
                foreach (var arg in args)
                {
                    Console.WriteLine($"{arg}");
                }
            }
            string readin;
            while ((readin = Console.ReadLine()) != "-end")
            {
                float num;
                if (float.TryParse(readin, out num))
                    Console.WriteLine($"{num}");
                else
                    Console.WriteLine("Invalid Value");
            }
        }
    }
}
