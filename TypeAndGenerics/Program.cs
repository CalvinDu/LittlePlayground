using System;
using System.Linq;

namespace TypeAndGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(typeof(IFoo).IsAssignableFrom(typeof(Foo1)));
            Console.WriteLine(new Foo1() is IBar);
            Console.WriteLine(typeof(Foo1).BaseType == typeof(Foo));
            Console.WriteLine(typeof(Foo1).GetInterfaces().Contains(typeof(IFoo)) );
            Console.WriteLine();
            Console.WriteLine(Check());

            Console.ReadKey();
        }

        public static bool Check(DateTime? dateTime = null)
        {
            return (dateTime is null);
        }
    }

    interface IFoo
    {
    }
    interface IBar
    {
    }
    abstract class Foo : IFoo
    {
    }
    class Foo1 : Foo,IBar
    {
    }
}
