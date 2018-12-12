using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnDotNet
{
    public static class Operator
    {
        private static int? someInt;
        public static int? GetSomeInt => someInt ?? (someInt = 1);

        public static void Go()
        {
            Console.WriteLine($"{nameof(Operator)}: someInt = {GetSomeInt}");
        }
    }
}
