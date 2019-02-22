using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnDotNet
{
    public class DefaultValue
    {
        public static void Go()
        {
            Console.WriteLine(default(int));
            Console.WriteLine(default(int?));
        }
    }
}
