using System;
using System.IO;

namespace DirectoryAndFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var subFolder1 = "sub1";
            var subFolder2 = "sub2";
            var path = Path.Combine(currentDirectory, subFolder1, subFolder2);

            var workingDirectory = new DirectoryInfo(path);
            if (!workingDirectory.Exists)
            {
                Console.WriteLine($"{workingDirectory.FullName} does not exist!");
                if (!workingDirectory.Parent.Exists)
                {
                   Console.WriteLine($"{workingDirectory.Parent.FullName} does not exist!");
                    if (!workingDirectory.Parent.Parent.Exists)
                    {
                        Console.WriteLine($"{workingDirectory.Parent.Parent.FullName} does not exist!");
                    }
                    else
                    {
                        Console.WriteLine($"{workingDirectory.Parent.Parent.FullName} exists!");
                    }
                }
                else
                {
                    Console.WriteLine($"{workingDirectory.Parent.FullName} exists!");
                }
            }
            else
            {
                Console.WriteLine($"{workingDirectory.FullName} exists!");  
            }

            Console.WriteLine(workingDirectory.Root.FullName);
            Console.WriteLine(workingDirectory.Name);
            workingDirectory.Create();
            workingDirectory.CreateSubdirectory("sub3/sub4");
            //var root = workingDirectory.Root;
            //while (workingDirectory.FullName!=workingDirectory.Root.FullName)
            //{
            //    workingDirectory = workingDirectory.Parent;
            //}
            //Console.WriteLine(workingDirectory.FullName);
            Console.ReadKey();
        }
    }
}
