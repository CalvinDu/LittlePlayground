using System;
using System.IO;

namespace IO
{
    class Program
    {
        static void Main(string[] args)
        {
            var fi = new FileInfo(@".\test.txt");
            Console.WriteLine("Hello World!");
        }


            const int megabyte = 1024 * 1024;

        public void ReadAndProcessLargeFile(string theFilename, long whereToStartReading = 0)
        {
            FileStream fileStram = new FileStream(theFilename, FileMode.Open, FileAccess.Read);
            using (fileStram)
            {
                byte[] buffer = new byte[megabyte];
                fileStram.Seek(whereToStartReading, SeekOrigin.Begin);
                int bytesRead = fileStram.Read(buffer, 0, megabyte);
                while (bytesRead > 0)
                {
                    ProcessChunk(buffer, bytesRead);
                    bytesRead = fileStram.Read(buffer, 0, megabyte);
                }

            }

        }
            private void ProcessChunk(byte[] buffer, int bytesRead)
            {
                // Do the processing here
            }
        
    }
}
