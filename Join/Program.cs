using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Join
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new List<string> {"first", "second", "third"};
            var y=x.Join("*");
            
            Console.WriteLine(y);
            Console.ReadKey();
        }
    }
}
