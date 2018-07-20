using System;

namespace DateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            var dateTime = System.DateTime.Now;
            
            Console.WriteLine(dateTime.AddDays(-(int)(dateTime.DayOfWeek)+1));

            Console.WriteLine(new System.DateTime(dateTime.Year, dateTime.Month, 1).AddMonths(7));
            Console.ReadKey();
        }
    }
}
