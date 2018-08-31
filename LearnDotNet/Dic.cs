using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnDotNet
{
    public static class Dic
    {
        public static void Play()
        {
            var dic = new Dictionary<SomeObject, string>();
            var obj = new SomeObject() { num1 = 1, num2 = 2 };

            dic.Add(new SomeObject() { num1 = 1, num2 = 2 }, "first pair");
            //dic.Add(new SomeObject() { num1 = 0, num2 = 3 }, "second pair");
            //dic.Add(new SomeObject() { num1 = 1, num2 = 3 }, "third pair");
            //dic.Add(new SomeObject() { num1 = 1, num2 = 2 }, "fourth pair");
            //foreach (var pair in dic)
            //{
            //    Console.WriteLine($"{pair.Value} : {pair.Key}");
            //}
            Console.WriteLine($"{dic.ContainsKey(new SomeObject() { num1 = 2, num2 = 2 })}");
            Console.WriteLine($"{dic.ContainsKey(new SomeObject() { num1 = 0, num2 = 3 })}");
            Console.WriteLine($"{dic.ContainsKey(new SomeObject() { num1 = 1, num2 = 3 })}");
            Console.WriteLine($"{dic.ContainsKey(new SomeObject() { num1 = 1, num2 = 2 })}");
        }
    }

    public class SomeObject
    {
        public int num1 { get; set; }
        public int num2 { get; set; }

        public override int GetHashCode()
        {
            return num1 + num2;
        }
        public override string ToString()
        {
            return $"num1: {num1}, num2: {num2}";
        }
        public override bool Equals(object obj)
        {
            var _obj = obj as SomeObject;
            return num1 == _obj.num1;
        }
    }
    
}
