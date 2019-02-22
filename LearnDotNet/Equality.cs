using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnDotNet
{
    public class Equality
    {
        private static CustomStruct customStruct = new CustomStruct();

        private static CustomClass customClass = new CustomClass();

        private static int someInt;
        public static void Go()
        {
            Console.WriteLine(EqualityTest1(customStruct));
            Console.WriteLine(EqualityTest2(customClass));
            Console.WriteLine(EqualityTest3(someInt));

        }

        private static bool EqualityTest1(CustomStruct cs)
        {
            cs.i++;
            return customStruct.Equals(cs);
        }

        private static bool EqualityTest2(CustomClass cc)
        {
            cc.i++;
            return customClass.Equals(cc);
        }

        private static bool EqualityTest3(int i)
        {
            i++;
            return someInt.Equals(i);
        }
    }

    internal struct CustomStruct
    {
        internal int i;
    }

    internal class CustomClass
    {
        internal int i;
    }
}
