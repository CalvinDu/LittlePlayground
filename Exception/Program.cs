using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            int text = 0;
            int test;
            try
            {
                test =  1/text;
                
                Console.WriteLine("Working Normally");
                
            }
            catch (System.Exception e)
            {
                Console.WriteLine($"{e}");
            }


            Console.ReadKey();


        }
    }
}
