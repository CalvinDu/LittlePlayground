using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;


namespace PlayThreading
{
    class Program
    {
        const string filePath = @"test.txt";

        static void Main(string[] args)
        {
            var stack = new Queue<int>();
            var str = "hello";
            var charA=str.ToCharArray();
            HashSet<char> set = new HashSet<char>(charA);
            set.
            foreach (var item in set)
            {
                Console.WriteLine($"{item}");
            }
            //WriteFile();
            ReadFile();
            Console.WriteLine("finished");
            Console.ReadKey();
        }

        public static async Task RunTask()
        {
            await Task.Run(() => {
                Thread.Sleep(1000);
                Console.WriteLine("Task is done");
            });
        }

        public static void WriteFile()
        {
            string[] dic = { "Hello", "NiHao", "BonJour", "Hi" };
            using (FileStream fs = new FileStream(filePath, FileMode.CreateNew))
            {
                using ( StreamWriter sw= new StreamWriter(fs))
                {
                    for (var i = 0; i < 1000; i++)
                    {
                        sw.WriteLine(dic[i%dic.Length]);
                    }
                }
            }
        }

        public static void ReadFile()
        {
            var dic = new Dictionary<string, uint>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                try
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (dic.ContainsKey(line))
                            dic[line]++;
                        else
                            dic.Add(line, 1);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
                finally
                {
                    foreach (var pair in dic)
                    {
                        Console.WriteLine($"{pair.Key}: {pair.Value}");
                    }
                }
            }
        }
    }
}
